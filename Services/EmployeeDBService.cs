using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshippClass.Data;
using InternshippClass.Models;
using Microsoft.Extensions.Configuration;

namespace InternshippClass.Services
{
    public class EmployeeDBService
    {
        private readonly InternDbContext db;
        private IConfiguration configuration;

        public EmployeeDBService(InternDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        public Employee AddEmployee(Employee employee)
        {
            db.Employees.AddRange(employee);
            db.SaveChanges();
            return employee;
        }

        public void RemoveEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee == null)
            {
                return;
            }

            db.Remove<Employee>(employee);
            db.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            return db.Find<Employee>(id);
        }

        public IList<Employee> GetEmployees()
        {
            var employee = db.Employees.ToList();
            return employee;
        }
    }
}
