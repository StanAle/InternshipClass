using InternshippClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshippClass.Services
{
    public interface IAddMemberSubscriber
    {
        void OnAddMember(Intern member);
    }
}
