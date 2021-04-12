using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshippClass.Models
{
    public class Message
    {
        public Message(string user, string message)
        {
            User = user;
            Content = message;
        }
        public string User { get; private set; }

        public string Content { get; private set; }
    }
}
