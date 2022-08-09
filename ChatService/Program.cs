using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatService
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleCtrlHandler.CleanUpOnClose();

            var server = new ChatServer(IPAddress.Any, 5000);

            server.ClientConnected += (obj, e) => Console.WriteLine($"Client Connected\nIP: {e.Client.IP}\nPort: {e.Client.Port}");

            server.Listen();
        }
    }
}
