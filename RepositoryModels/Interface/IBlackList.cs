using System.Collections.Generic;

namespace RepositoryModels
{
    public interface IBlackList
    {
        IEnumerable<IBlackListed> GetFilteredOb(int Filter);
    }
}