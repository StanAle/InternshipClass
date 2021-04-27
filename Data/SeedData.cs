using System;
using System.Linq;
using InternshippClass.Models;
using Microsoft.EntityFrameworkCore;

namespace InternshippClass.Data
{
    public static class SeedData
    {
        private static Location defaultLocation;

        public static void Initialize(InternDbContext context)
        {
            context.Database.Migrate();
            if (!context.Locations.Any())
            {
                var locations = new Location[]
                {
                    defaultLocation = new Location { Name = "Kyiv", NativeName = "Київ", Longitude = 30.5167, Latitude = 50.4333, },
                    new Location { Name = "Brasov", NativeName = "Braşov", Longitude = 25.3333, Latitude = 45.75, },
                };
                context.Locations.AddRange(locations);
                context.SaveChanges();
            }

            if (!context.Interns.Any())
            {
                var interns = new Intern[]
                {
                    new Intern { Id = 1, Name = "Vlad", RegistrationDateTime = DateTime.Parse("2021-04-04"), Location = defaultLocation },
                    new Intern { Id = 2, Name = "Liova", RegistrationDateTime = DateTime.Parse("2021-04-04"), Location = defaultLocation },
                    new Intern { Id = 3, Name = "Giulia", RegistrationDateTime = DateTime.Parse("2021-03-04"), Location = defaultLocation },
                };

                context.Interns.AddRange(interns);
                context.SaveChanges();
            }

            var projects = new Project[]
            {
                new Project
                {
                    Name = "Build a bot",
                    StartDate = DateTime.Parse("2020-09-01"),
                    Interns = context.Interns.ToList(),
                    Url = "https://gitlab.com/borysl/build-a-bot",
                    IsPublished = false,
                },
                new Project
                {
                    Name = "Multiplication table", 
                    StartDate = DateTime.Parse("2020-02-01"), 
                    Interns = new Intern[]
                    {
                        context.Interns.Single(_ => _.Name == "Liova"),
                    },
                    Url = "https://mtab.herokuapp.com/",
                    IsPublished = true,
                },
            };
            context.Projects.AddRange(projects);
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee
                {
                    FirstName = "Vlad", LastName = "Gogu", Birthdate = DateTime.Parse("1999-09-14"), Email = "vladgogu14@gmail.com", Gender="Male",Picture="picture"
                },
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
