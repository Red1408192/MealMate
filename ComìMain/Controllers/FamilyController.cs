using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ControllerModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace ComìMain.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class FamilyController : ControllerBase, IFamilyController
    {
        [HttpPatch]
        [Route("[action]")]
        public void AddDeseaseToBL(int Desease)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Route("[action]")]
        public void AddDietToBL(int Diet)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Route("[action]")]
        public void AddFlagToBL(int flag)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Route("[action]")]
        public void AddIngredientToBL(int ingredient)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<int> GetFamilyMembers(string user)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public FamMemberToSent GetFamMemberDetail(int famMember)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<string, int>> GetListDesease(int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<string, int>> GetListDiet(int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<string, int>> GetListFlag(int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<string, int>> GetListIngredient(int lang)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("[action]")]
        public void PostFamilyMember(FamMemberToPost famMemberToPost, string user)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public void UpdateFamMemberDetail(FamMemberToPost famMemberToPost, string user)
        {
            throw new NotImplementedException();
        }
    }
}
