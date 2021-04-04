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
        public void RemoveMember(int index)
        {
            intershipService.RemoveMember(index);
        }

        [HttpGet]
        public string AddMember(string member)
        {
            return intershipService.AddMember(member);
        }

        [HttpPut]
        public void UpdateMember(int index, string name)
        {
            intershipService.UpdateMembers(index, name);
        }

        public IActionResult Privacy()
        {
            return View(intershipService.GetClass());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
