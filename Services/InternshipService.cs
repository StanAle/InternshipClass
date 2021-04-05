using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshippClass.Models;

namespace InternshippClass.Services
{
    public class InternshipService
    {
        private readonly InternshipClass _internshipClass = new ();

        public void RemoveMember(int index)
        {
            _internshipClass.Members.RemoveAt(index);
        }

        public int AddMember(Intern intern)
        {
            _internshipClass.Members.Add(intern);
            return intern.Id;
        }

        public IList<Intern> GetMembers()
        {
            return _internshipClass.Members;
        }

        internal void UpdateMembers(int id, string memberName)
        {
            var itemToBeUpdated=_internshipClass.Members.SingleOrDefault(_ => _.Id == id);
            itemToBeUpdated.Name = memberName;
        }
    }
}
