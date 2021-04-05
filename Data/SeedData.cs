using InternshippClass.Models;
using System;
using System.Linq;

namespace InternshippClass.Data
{
    public static class SeedData
    {
        public static void Initialize(InternDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Interns.Any())
            {
                return;   // DB has been seeded
            }

            var interns = new Intern[]
            {
                new Intern {Id = 1, Name = "Vlad", RegistrationDateTime = DateTime.Parse("2021-04-04") },
                new Intern {Id = 2, Name = "Radu", RegistrationDateTime = DateTime.Parse("2021-04-04") },
                new Intern {Id = 3, Name = "Giulia", RegistrationDateTime = DateTime.Parse("2021-03-04") },
            };

            context.Interns.AddRange(interns);
            context.SaveChanges();
        }
    }
}
