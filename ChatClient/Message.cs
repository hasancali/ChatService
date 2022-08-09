using System;

namespace ChatClient
{
    public class Message
    {
        public string Sender { get; set; }

        public string To { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

    }
}
