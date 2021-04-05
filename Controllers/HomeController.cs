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
        private readonly InternshipService intershipService;
        private readonly InternDbContext db;

        public HomeController(ILogger<HomeController> logger, InternshipService intershipService, InternDbContext db)
        {
            _logger = logger;
            this.intershipService = intershipService;
            this.db = db;
        }

        public IActionResult Index()
        {
            var interns = db.Interns.ToList();
            return View(interns);
        }

        [HttpDelete]
        public void RemoveMember(int id)
        {
            intershipService.RemoveMember(id);
        }

        [HttpGet]
        public int AddMember(string memberName)
        {
            Intern intern = new Intern
            {
                Name = memberName,
            };
            return intershipService.AddMember(intern);
        }

        [HttpPut]
        public void UpdateMember(int id, string name)
        {
            intershipService.UpdateMembers(id, name);
        }

        public IActionResult Privacy()
        {
            return View(intershipService.GetMembers());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
