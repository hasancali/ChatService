using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatService
{
    public static class TcpClientExtentions
    {

        public static void Send(this TcpClient tcpClient, string data)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            NetworkStream stream = tcpClient.GetStream();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static string Receive(this TcpClient tcpClient, int size)
        {
            var buffer = new byte[size];

            NetworkStream stream = tcpClient.GetStream();
            stream.Read(buffer, 0, size);

            return Encoding.ASCII.GetString(buffer).TrimEnd(new char[] { (char)0 });
        }


        public static void Write(this NetworkStream networkStream, string data)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            networkStream.Write(buffer, 0, buffer.Length);
        }

        public static string Read(this NetworkStream networkStream, int size)
        {
            try
            {
                var buffer = new byte[size];
                networkStream.Read(buffer, 0, size);
                return Encoding.ASCII.GetString(buffer).TrimEnd(new char[] { (char)0 });
            }
            catch (Exception) { }

            return "";
        }

    }
}
