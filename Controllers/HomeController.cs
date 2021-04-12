using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InternshippClass.Data;
using InternshippClass.Models;
using InternshippClass.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InternshippClass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInternshipService intershipService;
        private readonly MessageService messageService;

        public HomeController(ILogger<HomeController> logger, IInternshipService intershipService, MessageService messageService)
        {
            _logger = logger;
            this.intershipService = intershipService;
            this.messageService = messageService;
        }

        public IActionResult Index()
        {
            var interns = intershipService.GetMembers();
            return View(interns);
        }

        [HttpDelete]
        public void RemoveMember(int id)
        {
            intershipService.RemoveMember(id);
        }

        [HttpGet]
        public Intern AddMember(string memberName)
        {
            Intern intern = new Intern
            {
                Name = memberName,
                RegistrationDateTime = DateTime.Now,
            };
            return intershipService.AddMember(intern);
        }

        [HttpPut]
        public void UpdateMember(int id, string memberName)
        {
            var intern = new Intern
            {
                Id = id,
                Name = memberName,
                RegistrationDateTime = DateTime.Now,
            };
            intershipService.UpdateMembers(intern);
        }

        public IActionResult Privacy()
        {
            return View(intershipService.GetMembers());
        }

        public IActionResult Chat()
        {
            return View(messageService.GetMessages());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
