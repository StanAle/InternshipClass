using InternshippClass.Models;
using InternshippClass.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshippClass.Hubs
{
    public class MessageHub : Hub, IAddMemberSubscriber
    {
        private readonly MessageService messageService;
        private readonly IInternshipService internshipService;
        public MessageHub(MessageService messageService, IInternshipService internshipService)
        {
            this.messageService = messageService;
            this.internshipService = internshipService;
            internshipService.SubscribeToAddMember(this);
        }

        public async Task SendMessage(string user, string message)
        {
            Message messageObj = new Message(user, message);
            messageService.AddMessage(messageObj);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
