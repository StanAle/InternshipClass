using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InternshippClass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InternshhipMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly InternshipClass _internshipClass;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _internshipClass = new InternshipClass();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public void RemoveMember(int index)
        {
            _internshipClass.Members.RemoveAt(index);
        }

        [HttpGet]
        public string AddMember(string member)
        {
            _internshipClass.Members.Add(member);
            return member;
        }

        public IActionResult Privacy()
        {
            return View(_internshipClass);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
