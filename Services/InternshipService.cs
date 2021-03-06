using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshippClass.Models;

namespace InternshippClass.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly InternshipClass _internshipClass = new ();

        public void RemoveMember(int id)
        {
            var itemToBeDeleted = GetMemberById(id);
            _internshipClass.Members.Remove(itemToBeDeleted);
        }

        public Intern AddMember(Intern intern)
        {
            var maxId = _internshipClass.Members.Max(_ => _.Id);
            var newId = maxId + 1;
            intern.Id = newId;
            _internshipClass.Members.Add(intern);
            return intern;
        }

        public IList<Intern> GetMembers()
        {
            return _internshipClass.Members;
        }

        public void UpdateMembers(Intern intern)
        {
            var itemToBeUpdated = GetMemberById(intern.Id);
            itemToBeUpdated.Name = intern.Name;
        }

        public Intern GetMemberById(int id)
        {
            return _internshipClass.Members.Single(_ => _.Id == id);
        }
    }
}
