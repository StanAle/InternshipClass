using InternshippClass.Hubs;
using InternshippClass.Models;
using System.Collections.Generic;

namespace InternshippClass.Services
{
    public interface IInternshipService
    {
        Intern AddMember(Intern intern);

        IList<Intern> GetMembers();

        void RemoveMember(int id);

        void UpdateMembers(Intern intern);

        Intern GetMemberById(int id);
    }
}