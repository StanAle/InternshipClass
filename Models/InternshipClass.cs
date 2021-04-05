using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshippClass.Models
{
    public class InternshipClass
    {
        private List<Intern> _members;

        public InternshipClass()
        {
            _members = new List<Intern> 
            {
                 new Intern { Name = "Vlad", RegistrationDateTime = DateTime.Parse("2021-04-04") },
                new Intern { Name = "Radu", RegistrationDateTime = DateTime.Parse("2021-04-04") },
                new Intern { Name = "Giulia", RegistrationDateTime = DateTime.Parse("2021-03-04") },
            };
        }

        public IList<Intern> Members
        {
            get { return _members; }
        }
    }
}
