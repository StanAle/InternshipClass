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
        public MessageHub(MessageService messageService)
        {
            this.messageService = messageService;
        }

        public async void OnAddMember(Intern member)
        {
            await Clients.All.SendAsync("AddMember", member.Name, member.Id);
        }

        public async Task SendMessage(string user, string message)
        {
            Message messageObj = new Message(user, message);
            messageService.AddMessage(messageObj);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}
