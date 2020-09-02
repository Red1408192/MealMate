using System;
using System.Collections.Generic;
using System.Linq;
using MealMate.Data;
using MealMate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MealMate.Controllers
{
    [Authorize] //[AllowAnonymous]
    [Route("[controller]")]
    public class FamilyMemberController : ControllerBase
    {
        MealMateNewContext context;

        public FamilyMemberController(MealMateNewContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("[action]")]
        public void Post([FromBody] object request)
        {
            familyMemberToRead fam = JsonConvert.DeserializeObject<familyMemberToRead>(request.ToString());
            string userId = this.HttpContext.User.Claims.ToList()[5].Value;
            UserFamily uFamily = new UserFamily()
            {
                Name = fam.name,
                SecondName = fam.secondName,
                CultureId = fam.cultureId,
                IsGuest = fam.isGuest,
                UserId = userId
            };

            context.Add(uFamily);
            context.SaveChanges();

            foreach (var desId in fam.deseases)
            {
                UserFamilyDesease userFamilyDesease = new UserFamilyDesease()
                {
                    DeseaseId = desId,
                    UserFamilyMemberId = uFamily.FamilyMember                
                };
                context.Add(userFamilyDesease);
                context.SaveChanges();
            }
            foreach (var dieId in fam.diets)
            {
                UserFamilyDiet  useDiet = new UserFamilyDiet()
                {
                    DietId = dieId,
                    UserFamilyMemberId = uFamily.FamilyMember
                };
                context.Add(useDiet);
                context.SaveChanges();
            }
            foreach (var ingId in fam.ingrs)
            {
                UserFamilyDietIngr useIngr = new UserFamilyDietIngr()
                {
                    IngredientId = ingId,
                    FamilyMemberId = uFamily.FamilyMember
                };
                context.Add(ingId);
                context.SaveChanges();
            }
            foreach (var flag in fam.flags)
            {
                UserFamilyDietFlag usefla = new UserFamilyDietFlag()
                {
                    FlagId = flag,
                    FamilyMemberId = uFamily.FamilyMember
                };
                context.Add(usefla);
                context.SaveChanges();
            }
        }

        [HttpGet]
        [Authorize()] //need to lock the requester to the user
        [Route("[action]/{id:int}/{lang:int}")]
        public string Get(int id, int lang)
        {
            UserFamily query = context.UserFamily.Where(a => a.FamilyMember == id).FirstOrDefault();

            IEnumerable<KeyValuePair<int, string>> desL;
            IEnumerable<KeyValuePair<int, string>> dietL;
            IEnumerable<KeyValuePair<int, string>> ingrsL;
            IEnumerable<KeyValuePair<int, string>> flagsL;

            desL = context.UserFamilyDesease
                .Where(a => a.UserFamilyMemberId == id)
                .Select(b => new KeyValuePair<int, string>(b.DeseaseId, 
                context.LocalizationTable
                    .Where(c => c.ElementId == b.Desease.DeseaseNameId && c.LanguageId == lang)
                    .FirstOrDefault()
                    .Localization
                    )
                );

            dietL = context.UserFamilyDiet
                .Where(a => a.UserFamilyMemberId == id)
                .Select(b => new KeyValuePair<int, string>(b.DietId,
                context.LocalizationTable
                    .Where(c => c.ElementId == b.Diet.DietNameId && c.LanguageId == lang)
                    .FirstOrDefault()
                    .Localization
                    )
                );

            ingrsL = context.UserFamilyDietIngr
                .Where(a => a.FamilyMemberId == id)
                .Select(b => new KeyValuePair<int, string>(b.IngredientId,
                context.LocalizationTable
                    .Where(c => c.ElementId == b.Ingredient.IngNameId && c.LanguageId == lang)
                    .FirstOrDefault()
                    .Localization
                    )
                );

            flagsL = context.UserFamilyDietFlag
                .Where(a => a.FamilyMemberId == id)
                .Select(b => new KeyValuePair<int, string>(b.FlagId,
                context.LocalizationTable
                    .Where(c => c.ElementId == b.Flag.FlagNameId && c.LanguageId == lang)
                    .FirstOrDefault()
                    .Localization
                    )
                );

            familyMemberToSent familyMember = new familyMemberToSent
            {
                id = query.FamilyMember,
                userId = query.UserId,
                name = query.Name,
                secondName = query.SecondName,
                cultureId = query.CultureId,
                isGuest = query.IsGuest,
                ingrs = ingrsL,
                deseases = desL,
                diets = dietL,
                flags = flagsL
            };
            return JsonConvert.SerializeObject(familyMember, Formatting.Indented);
        }

        [HttpPost]
        [Authorize()] //need to lock the requester to the user
        [Route("[action]")]
        public void SetDiet([FromBody] object request)
        {

             settingModification mod = JsonConvert.DeserializeObject<settingModification>(request.ToString());
            
            switch (mod.setModind)
            {
                case 0:
                    UserFamilyDesease res0 = new UserFamilyDesease() {DeseaseId = mod.ElemenId, UserFamilyMemberId = mod.famMemberId };
                    context.Add(res0);
                    break;
                case 1:
                    UserFamilyDiet res1 = new UserFamilyDiet() { DietId = mod.ElemenId, UserFamilyMemberId = mod.famMemberId };
                    context.Add(res1);
                    break;
                case 2:
                    UserFamilyDietIngr res2 = new UserFamilyDietIngr() { IngredientId = mod.ElemenId, FamilyMemberId = mod.famMemberId };
                    context.Add(res2);
                    break;
                case 3:
                    UserFamilyDietFlag res3 = new UserFamilyDietFlag() { FlagId = mod.ElemenId, FamilyMemberId = mod.famMemberId };
                    context.Add(res3);
                    break;
                case 4:
                    UserFamilyDesease res4 = context.UserFamilyDesease.Where(a => a.UserFamilyMemberId == mod.famMemberId && a.DeseaseId == mod.ElemenId).FirstOrDefault();
                    context.Remove(res4);
                    break;
                case 5:
                    UserFamilyDiet res5 = context.UserFamilyDiet.Where(a => a.UserFamilyMemberId == mod.famMemberId && a.DietId == mod.ElemenId).FirstOrDefault();
                    context.Remove(res5);
                    break;
                case 6:
                    UserFamilyDietIngr res6 = context.UserFamilyDietIngr.Where(a => a.FamilyMemberId == mod.famMemberId && a.IngredientId == mod.ElemenId).FirstOrDefault();
                    context.Remove(res6);
                    break;
                case 7:
                    UserFamilyDietFlag res7 = context.UserFamilyDietFlag.Where(a => a.FamilyMemberId == mod.famMemberId && a.FlagId == mod.ElemenId).FirstOrDefault();
                    context.Remove(res7);
                    break;
            }
        }

        [HttpDelete]
        [Route("[action]/{id:int}/{lang:int}")]
        public void Delete(int id, int lang)
        {

        }

        //internal-models
        internal class familyMemberToRead
        {
            [JsonProperty]
            internal int id { get; set; }
            [JsonProperty]
            internal string name { get; set; }
            [JsonProperty]
            internal string secondName { get; set; }
            [JsonProperty]
            internal int cultureId { get; set; }
            [JsonProperty]
            internal bool isGuest { get; set; }
            [JsonProperty]
            internal int userId { get; set; }
            [JsonProperty]
            internal IEnumerable<int> deseases { get; set; }
            [JsonProperty]
            internal IEnumerable<int> diets { get; set; }
            [JsonProperty]
            internal IEnumerable<int> flags { get; set; }
            [JsonProperty]
            internal IEnumerable<int> ingrs { get; set; }
        }

        internal class familyMemberToSent
        {
            [JsonProperty]
            internal int id { get; set; }
            [JsonProperty]
            internal string userId { get; set; }
            [JsonProperty]
            internal string name { get; set; }
            [JsonProperty]
            internal string secondName { get; set; }
            [JsonProperty]
            internal int cultureId { get; set; }
            [JsonProperty]
            internal bool isGuest { get; set; }
            [JsonProperty]
            internal IEnumerable<KeyValuePair<int,string>> deseases { get; set; }
            [JsonProperty]
            internal IEnumerable<KeyValuePair<int, string>> diets { get; set; }
            [JsonProperty]
            internal IEnumerable<KeyValuePair<int, string>> flags { get; set; }
            [JsonProperty]
            internal IEnumerable<KeyValuePair<int, string>> ingrs { get; set; }
        }

        internal class settingModification
        {
            [JsonProperty]
            internal int setModind { get; set; } // 0 - add desease; 1 - add diet; 2 - add flag to black list; 3 - add ingredient to black list
                                                 // 4 - remove desease; 5 - remove diet: 6 - remove flag From black list, 7 - remove ingredient From black list
            [JsonProperty]
            internal int famMemberId { get; set; }
            [JsonProperty]
            internal int ElemenId { get; set; }
        }
    }
}
