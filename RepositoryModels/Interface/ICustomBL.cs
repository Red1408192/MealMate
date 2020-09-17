using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModels
{
    public interface ICustomBL : IBlackList
    {
        void AddFilterToCustom(string userId, int familyMember, int blackListedId, bool isFlag);
    }
}
