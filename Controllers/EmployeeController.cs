using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshippClass.Models;
using InternshippClass.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshippClass.Controllers
{
    [Route("employee/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDBService employeeDbService;

        public EmployeeController(EmployeeDBService employeeDbService)
        {
            this.employeeDbService = employeeDbService;
        }

        [HttpGet]
        public IList<Employee> Get()
        {
            return employeeDbService.GetEmployees();
        }

        // GET employee/<InternshipController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employeeDbService.GetEmployeeById(id);
        }

        // POST employee/<InternshipController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            var newEmployee = employeeDbService.AddEmployee(employee);
        }
    }
}
