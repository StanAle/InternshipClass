using InternshippClass.Data;
using InternshippClass.Hubs;
using InternshippClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshippClass.Services
{
    public class InternshipDBService : IInternshipService
    {
        private readonly InternDbContext db;

        public InternshipDBService(InternDbContext db)
        {
            this.db = db;
        }

        public Intern AddMember(Intern intern)
        {
            db.Interns.AddRange(intern);
            db.SaveChanges();
            return intern;
        }

        public Intern GetMemberById(int id)
        {
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
            db.Remove<Intern>(intern);
            db.SaveChanges();
        }

        public void UpdateMembers(Intern intern)
        {
            db.Update<Intern>(intern);
            intern.RegistrationDateTime = DateTime.Now;
            db.SaveChanges();
        }
    }
}
