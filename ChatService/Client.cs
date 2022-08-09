using System.Net;
using System.Net.Sockets;

namespace ChatService
{
    public class Client
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public IPAddress IP { get; set; }
        public int Port { get; set; }

        public TcpClient TcpClient { get; set; }
        public NetworkStream NetworkStream { get; set; }


        public Client(TcpClient tcpClient)
        {
            TcpClient = tcpClient;
            NetworkStream = tcpClient.GetStream();

            var remoteEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;

            IP = remoteEndPoint.Address;
            Port = remoteEndPoint.Port;
        }

    }
}
