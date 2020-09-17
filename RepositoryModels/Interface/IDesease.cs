using System.Collections.Generic;

namespace RepositoryModels
{
    public interface IDesease : IBlackList
    {
        IEnumerable<Diet> GetFMDesease(string user, int familyMember);
        void AddDeseaseToUser(int deseaseId, string userId, int familyMember);
    }
}