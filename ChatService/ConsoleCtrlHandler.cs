using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatService
{
    public class ConsoleCtrlHandler
    {
        static ConsoleEventDelegate handler;   // Keeps it from getting garbage collected

        // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);


        public static void CleanUpOnClose()
        {
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);
        }

        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                foreach (var process in Process.GetProcessesByName("Chat.WinForms"))
                    process.Kill();
            }
            return false;
        }
    }
}
