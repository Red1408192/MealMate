using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ControllerModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace Comì.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class FamilyController : ControllerBase, IFamilyController
    {
        public void AddDeseaseToBL(int Desease)
        {
            throw new NotImplementedException();
        }

        public void AddDietToBL(int Diet)
        {
            throw new NotImplementedException();
        }

        public void AddFlagToBL(int flag)
        {
            throw new NotImplementedException();
        }

        public void AddIngredientToBL(int ingredient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetFamilyMembers(string user)
        {
            throw new NotImplementedException();
        }

        public FamMemberToSent GetFamMemberDetail(int famMember)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, int>> GetListDesease(int lang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, int>> GetListDiet(int lang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, int>> GetListFlag(int lang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, int>> GetListIngredient(int lang)
        {
            throw new NotImplementedException();
        }

        public void PostFamilyMember(FamMemberToPost famMemberToPost, string user)
        {
            throw new NotImplementedException();
        }

        public void UpdateFamMemberDetail(FamMemberToPost famMemberToPost, string user)
        {
            throw new NotImplementedException();
        }
    }
}
