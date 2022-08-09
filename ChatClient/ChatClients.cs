using ChatService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{
    public class ChatClients
    {
        private readonly TcpClient server;

        private bool running;

        public List<Client> ConnectedClients { get; private set; }

        public event EventHandler<ConnectionEventArgs> ClientConnected;
        public event EventHandler<ConnectionEventArgs> ClientDisconnected;

        public event EventHandler<MessageEventArgs> MessageSent;
        public event EventHandler<MessageEventArgs> MessageReceived;

        public string Username { get; private set; }
        public int ListeningPort { get; set; }

        public Thread ListenThread { get; set; }

        public List<Chat> Chats { get; set; }


        public ChatClients()
        {
            server = new TcpClient();
            ConnectedClients = new List<Client>();
            running = true;

            Chats = new List<Chat>();

            MessageReceived += ChatClient_MessageReceived;
            MessageSent += ChatClient_MessageSent;
        }

        private void ChatClient_MessageSent(object sender, MessageEventArgs e)
        {
            var chat = Chats.Find(c => c.User == e.Client.Username);

            if (chat == null)
            {
                chat = new Chat() { User = e.Client.Username };
                chat.Messages.Add(e.Message);
                Chats.Add(chat);
            }
            else
            {
                chat.Messages.Add(e.Message);
            }
        }

        private void ChatClient_MessageReceived(object sender, MessageEventArgs e)
        {
            var chat = Chats.Find(c => c.User == e.Client.Username);

            if (chat == null)
            {
                chat = new Chat() { User = e.Client.Username };
                chat.Messages.Add(e.Message);
                Chats.Add(chat);
            }
            else
            {
                chat.Messages.Add(e.Message);
            }
        }

        public void ConnectToServer(IPAddress serverIP, int serverPort)
        {
            server.Connect(serverIP, serverPort);
        }

        private void Send(string data, TcpClient tcpClient)
        {
            //lock (_lock)
            //{
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            NetworkStream stream = tcpClient.GetStream();
            stream.Write(buffer, 0, buffer.Length);
            //}
        }

        public void SendToServer(string data)
        {
            Send(data, server);
        }

        public void SendToClient(string data, Client client)
        {
            Send(data, client.TcpClient);

            var message = new Message() { Sender = this.Username, To = client.Username, Content = data, Date = DateTime.Now };
            MessageSent?.Invoke(this, new MessageEventArgs(client, message));
        }

        public Client ConnectToClient(string username)
        {
            if (IsUserConnected(username))
            {
                var user = GetUser(username);

                var tcpClient = new TcpClient();
                tcpClient.Connect(user.Address, user.Port);

                var client = new Client(tcpClient) { Username = username };
                ConnectedClients.Add(client);

                ClientConnected?.Invoke(this, new ConnectionEventArgs(client));

                SendToServer($"connectedto {username}");

                StartReceive(client);

                return client;
            }

            return null;
        }


        public void Listen()
        {
            ListenThread = new Thread(() =>
            {
                TcpListener ServerSocket = new TcpListener(IPAddress.Any, 0);
                ServerSocket.Start();

                ListeningPort = ((IPEndPoint)ServerSocket.LocalEndpoint).Port;
                SendListeningPort(ListeningPort);

                while (running)
                {
                    TcpClient tcpClient = ServerSocket.AcceptTcpClient();

                    var client = new Client(tcpClient) { Username = server.Receive(1024) };

                    ConnectedClients.Add(client);

                    ClientConnected?.Invoke(this, new ConnectionEventArgs(client));

                    StartReceive(client);
                }

                ServerSocket.Stop();
            });

            ListenThread.Start();
        }

        public void StartReceive(Client client)
        {
            var receiveTask = Task.Run(() =>
            {
                while (running && client.TcpClient != null && client.TcpClient.Connected)
                {
                    var message = new Message()
                    {
                        Sender = client.Username,
                        To = this.Username,
                        Content = client.NetworkStream.Read(1024),
                        Date = DateTime.Now
                    };

                    if (message.Content == "disconnect")
                        break;

                    MessageReceived?.Invoke(this, new MessageEventArgs(client, message));
                }

                Disconnect(client);
            });
        }



        #region Server Communications

        public void Login(string username, string password)
        {
            SendToServer($"login {this.Username = username}:{password}");
        }

        private void SendListeningPort(int port)
        {
            SendToServer($"port {port}");
        }

        public bool IsUserConnected(string username)
        {
            SendToServer($"connected {username}");

            return server.Receive(1024).Split(' ')[0] == "302";
        }

        public IPEndPoint GetUser(string username)
        {
            if (!IsUserConnected(username))
                return null;

            SendToServer($"user {username}");

            var temp = server.Receive(1024).Split(':');
            return new IPEndPoint(IPAddress.Parse(temp[0]), int.Parse(temp[1]));
        }

        public string GetUsername(TcpClient tcpClient)
        {
            var remoteEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;

            var ip = remoteEndPoint.Address;
            var port = remoteEndPoint.Port;
            SendToServer($"username {ip}:{port}");

            return server.Receive(1024);
        }

        public List<string> GetAllUsers()
        {
            SendToServer($"users");

            return server.Receive(1024).Split(' ').ToList();
        }

        public void Disconnect()
        {
            running = false;

            for (int i = 0; i < ConnectedClients.Count; i++)
                Disconnect(ConnectedClients[i]);

            ConnectedClients.Clear();

            server.Send("disconnect");
        }

        public void Disconnect(Client client)
        {
            client.NetworkStream.Write("disconnect");

            client.TcpClient.Client.Shutdown(SocketShutdown.Both);
            client.NetworkStream.Close();
            client.TcpClient.Close();

            ConnectedClients.Remove(client);

            ClientDisconnected?.Invoke(this, new ConnectionEventArgs(client));
        }

        #endregion


    }
}
