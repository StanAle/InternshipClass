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
        private readonly List<IAddMemberSubscriber> subscribers;

        public InternshipDBService(InternDbContext db)
        {
            this.db = db;
            subscribers = new List<IAddMemberSubscriber>();
        }

        public Intern AddMember(Intern intern)
        {
            db.Interns.AddRange(intern);
            db.SaveChanges();
            subscribers.ForEach(subscriber => subscriber.OnAddMember(intern));
            return intern;
        }

        public IList<Intern> GetMembers()
        {
            var interns = db.Interns.ToList();
            return interns;
        }

        public void RemoveMember(int id)
        {
            var intern = db.Find<Intern>(id);
            db.Remove<Intern>(intern);
            db.SaveChanges();
        }

        public void UpdateMembers(Intern intern)
        {
            db.Update<Intern>(intern);
            db.SaveChanges();
        }

        public void SubscribeToAddMember(IAddMemberSubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }
    }
}
