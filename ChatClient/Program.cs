using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            //int port = 5000;
            //TcpClient client = new TcpClient();
            //client.Connect(ip, port);
            //Console.WriteLine("client connected!!");
            //NetworkStream ns = client.GetStream();
            //Thread thread = new Thread(o => ReceiveData((TcpClient)o));

            //thread.Start(client);

            //string s;
            //while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            //{
            //    byte[] buffer = Encoding.ASCII.GetBytes(s);
            //    ns.Write(buffer, 0, buffer.Length);
            //}

            //client.Client.Shutdown(SocketShutdown.Send);
            //thread.Join();
            //ns.Close();
            //client.Close();
            //Console.WriteLine("disconnect from server!!");
            //Console.ReadKey();


            var client = new ChatClients();

            client.ClientConnected += (obj, e) => Console.WriteLine($"Client Connected\nIP: {e.Client.IP}\nPort: {e.Client.Port}");

            client.MessageReceived += (obj, e) => Console.WriteLine($"{e.Message} (from{e.Client.Username})");

            client.ConnectToServer(IPAddress.Parse("192.168.1.35"), 5000);

            var username = Console.ReadLine();
            var password = Console.ReadLine();
            client.Login(username, password);

            client.Listen();


            //var users = client.GetAllUsers();

            var connectToUser = Console.ReadLine();

            if (!string.IsNullOrEmpty(connectToUser))
            {
                //var user = client.GetUser(connectToUser);

                client.ConnectToClient(connectToUser);
            }



            if (client.ConnectedClients.Count > 0)
            {
                client.SendToClient("Hi, User", client.ConnectedClients[0]);

                while (true)
                {
                    string s = Console.ReadLine();

                    client.SendToClient(s, client.ConnectedClients[0]);
                }
            }





            //client.ListenThread.Join();

            //client.SendThread.Join();

            //client.ReceiveThread.Join();

            //Task.WaitAll();



            //Console.ReadKey();

        }

        static void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                Console.Write(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
            }
        }
    }
}
