using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoryModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace Comì.Repositories
{
    public class UserRepository : IUserRepository
    {
        public AccountSettings GetAccountSettings(string id)
        {
            throw new NotImplementedException();
        }

        public FamilyMember GetFamilyMember(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FamilyMember> GetFamilyMembers(string id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
