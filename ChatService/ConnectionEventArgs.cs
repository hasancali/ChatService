using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatService
{
    public class ConnectionEventArgs : EventArgs
    {
        public Client Client { get; set; }

        public ConnectionEventArgs(Client client)
        {
            Client = client;
        }
    }   
}
