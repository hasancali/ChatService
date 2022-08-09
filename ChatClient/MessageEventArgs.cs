using ChatService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class MessageEventArgs : EventArgs
    {
        public Client Client { get; set; }
        public Message Message { get; set; }

        public MessageEventArgs(Client client, Message message)
        {
            Client = client;
            Message = message;
        }

    }
}
