using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModels
{
    public interface IUserRepository
    {
        User GetUser(string id);
        FamilyMember GetFamilyMember(string id);
        IEnumerable<FamilyMember> GetFamilyMembers(string id);

    }
}
