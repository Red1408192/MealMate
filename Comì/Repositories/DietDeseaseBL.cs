using RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comì.Repositories
{
    public class DietDeseaseBL : IDiet, IDesease, ICustomBL
    {
        public void AddDeseaseToUser(int deseaseId, string userId, int familyMember)
        {
            throw new NotImplementedException();
        }

        public void AddDietToUser(int dietId, string userId, int familyMember)
        {
            throw new NotImplementedException();
        }

        public void AddFilterToCustom(string userId, int familyMember, int blackListedId, bool isFlag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBlackListed> GetFilteredOb(int Filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diet> GetFMDesease(string user, int familyMember)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diet> GetFMDiet(string user, int familyMember)
        {
            throw new NotImplementedException();
        }
    }
}
