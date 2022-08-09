using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatService
{
    public class ChatServer
    {
        public IPAddress IP { get; set; }
        public int Port { get; set; }

        public List<Client> Clients { get; set; }

        public event EventHandler<ConnectionEventArgs> ClientConnected;

        public ChatServer(IPAddress ip, int port)
        {
            IP = ip;
            Port = port;

            Clients = new List<Client>();
        }

        public void Listen()
        {
            TcpListener ServerSocket = new TcpListener(IP, Port);
            ServerSocket.Start();

            while (true)
            {
                TcpClient tcpClient = ServerSocket.AcceptTcpClient();

                var client = new Client(tcpClient);

                Clients.Add(client);

                ClientConnected?.Invoke(this, new ConnectionEventArgs(client));

                new Thread(() => StartRecieve(client)).Start();
            }
        }

        private void StartRecieve(Client client)
        {
            while (client.TcpClient != null && client.TcpClient.Connected)
            {
                var command = client.NetworkStream.Read(1024);

                Execute(command, client);
            }
        }


        private void Execute(string command, Client client)
        {
            var loginMatch = Regex.Match(command, "login (?<username>.*?):(?<password>.*)");
            if (loginMatch.Success)
                Login(loginMatch.Groups["username"].Value, loginMatch.Groups["password"].Value, client);


            var userMatch = Regex.Match(command, "user (?<username>.*)");
            if (userMatch.Success)
            {
                var user = Clients.Find(usr => usr.Username == userMatch.Groups["username"].Value);

                if (user != null)
                    client.NetworkStream.Write($"{user.IP}:{user.Port}");
                else
                    client.NetworkStream.Write($"User doesn't exist");
            }


            var connectedMatch = Regex.Match(command, "connected (?<username>.*)");
            if (connectedMatch.Success)
            {
                if (IsUserConnected(connectedMatch.Groups["username"].Value))
                {
                    client.NetworkStream.Write($"302 Found");
                }
                else
                {
                    client.NetworkStream.Write($"404 Not Found");
                }
            }


            var usersMatch = Regex.Match(command, "users");
            if (usersMatch.Success)
            {
                var users = string.Join(" ", Clients.Select(c => c.Username));
                client.NetworkStream.Write(users);
            }


            var portMatch = Regex.Match(command, @"port (?<port>\d+)");
            if (portMatch.Success)
                client.Port = int.Parse(portMatch.Groups["port"].Value);


            var usernameMatch = Regex.Match(command, "username (?<ip>.*?):(?<port>.*)");
            if (usernameMatch.Success)
            {
                var ip = IPAddress.Parse(usernameMatch.Groups["ip"].Value);
                var port = int.Parse(usernameMatch.Groups["port"].Value);

                client.NetworkStream.Write(Clients.Find(c => ip == c.IP && port == c.Port).Username);
            }


            var connectedToMatch = Regex.Match(command, "connectedto (?<username>.*)");
            if (connectedToMatch.Success)
            {
                var username = connectedToMatch.Groups["username"].Value;
                Clients.Find(c => c.Username == username).NetworkStream.Write(client.Username);
            }


            var disconnectMatch = Regex.Match(command, "disconnect");
            if (disconnectMatch.Success)
                Clients.Remove(client);

        }

        public bool Login(string username, string password, Client client)
        {
            if (IsUserConnected(username))
                return false;

            client.Username = username;
            client.Password = password;
            return true;
        }

        public bool IsUserConnected(string username)
        {
            return Clients.Exists(c => c.Username == username);
        }

    }
}
