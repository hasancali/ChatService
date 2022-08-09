using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class Chat
    {

        public string User { get; set; }

        public List<Message> Messages { get; set; }


        public Chat()
        {
            Messages = new List<Message>();
        }

    }
}
