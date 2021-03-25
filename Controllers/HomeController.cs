using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InternshippClass.Models;
using InternshippClass.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InternshhipMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InternshipService intershipService;

        public HomeController(ILogger<HomeController> logger, InternshipService intershipService)
        {
            _logger = logger;
            this.intershipService = intershipService;
        }

        public IActionResult Index()
        {
            return View();
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
