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

        public InternshipClass GetClass()
        {
            return _internshipClass;
        }

        internal void UpdateMembers(Intern intern)
        {
            _internshipClass.Members[intern.Id] = intern;
        }
    }
}
