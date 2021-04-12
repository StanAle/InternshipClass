using InternshippClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshippClass.Services
{
    public class MessageService
    {
        private readonly List<Message> allMessages;

        public MessageService()
        {
            allMessages = new List<Message>();
        }

        public List<Message> GetMessages()
        {
            return allMessages;
        }

        public void AddMessage(Message message)
        {
            allMessages.Add(message);
        }
    }
}
