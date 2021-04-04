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
                new Intern { Name = "Vlas", RegistrationDateTime = DateTime.Parse("2021-04-04") },
                new Intern { Name = "Radu", RegistrationDateTime = DateTime.Parse("2021-04-04") },
                new Intern { Name = "Giulia", RegistrationDateTime = DateTime.Parse("2021-03-04") },
            };

            context.Interns.AddRange(interns);
            context.SaveChanges();
        }
    }
}
