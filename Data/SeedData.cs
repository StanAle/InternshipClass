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
                    new Intern { Id = 2, Name = "Radu", RegistrationDateTime = DateTime.Parse("2021-04-04"), Location = defaultLocation },
                    new Intern { Id = 3, Name = "Giulia", RegistrationDateTime = DateTime.Parse("2021-03-04"), Location = defaultLocation },
                };

                context.Interns.AddRange(interns);
                context.SaveChanges();
            }
        }
    }
}
