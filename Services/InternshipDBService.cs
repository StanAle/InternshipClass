using System;
using System.Collections.Generic;
using System.Linq;
using InternshippClass.Data;
using InternshippClass.Hubs;
using InternshippClass.Models;
using Microsoft.Extensions.Configuration;

namespace InternshippClass.Services
{
    public class InternshipDBService : IInternshipService
    {
        private readonly InternDbContext db;
        private IConfiguration configuration;
        private Location defaultLocation;

        public InternshipDBService(InternDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        public Intern AddMember(Intern intern)
        {
            if (intern.Location == null)
            {
                intern.Location = GetDefaultLocation();
            }

            db.Interns.AddRange(intern);
            db.SaveChanges();
            return intern;
        }

        public Intern GetMemberById(int id)
        {
            var intern = db.Find<Intern>(id);
            db.Entry(intern).Reference(_ => _.Location).Load();
            return db.Find<Intern>(id);
        }

        public IList<Intern> GetMembers()
        {
            var interns = db.Interns.ToList();
            return interns;
        }

        public void RemoveMember(int id)
        {
            var intern = GetMemberById(id);
            if (intern == null)
            {
                return;
            }

            db.Remove<Intern>(intern);
            db.SaveChanges();
        }

        public void UpdateMembers(Intern intern)
        {
            db.Update<Intern>(intern);
            intern.RegistrationDateTime = DateTime.Now;
            db.SaveChanges();
        }

        private Location GetDefaultLocation()
        {
            if (defaultLocation == null)
            {
                var defaultLocationName = configuration["DefaultLocation"];
                defaultLocation = db.Locations.Where(_ => _.Name == defaultLocationName).OrderBy(_ => _.Id).FirstOrDefault();
            }

            return defaultLocation;
        }
    }
}
