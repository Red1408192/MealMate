using System.Collections.Generic;

namespace RepositoryModels
{
    public interface IDiet : IBlackList
    {
        IEnumerable<Diet> GetFMDiet(string user, int familyMember);
        void AddDietToUser(int dietId, string userId, int familyMember);
    }
}