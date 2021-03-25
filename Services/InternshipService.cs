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

        public string AddMember(string member)
        {
            _internshipClass.Members.Add(member);
            return member;
        }

        public InternshipClass GetClass()
        {
            return _internshipClass;
        }
    }
}
