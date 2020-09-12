using System;
using System.Collections.Generic;
using System.Linq;
using MealMate.Data;
using MealMate.Services;
using MealMate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MealMate.Controllers
{
    [Authorize] //[AllowAnonymous]
    [Route("[controller]")]
    public class MealController : ControllerBase
    {
        MealMateNewContext context;

        public MealController(MealMateNewContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("[action]")]
        public string Generate([FromBody] object request)
        {
            var user = this.User.Claims.ToList()[5].Value;

            Parameter parameter = JsonConvert.DeserializeObject<Parameter>(request.ToString());
            parameter.Normalize();

            if (parameter.famBlackList)
            {
                IEnumerable<UserFamily> family = context
                    .UserFamily.Where(a => a.UserId == user)
                    .Where(a => parameter.familyMembers
                    .Contains(a.FamilyMember));

                IEnumerable<Flag> flagList = context.Flag
                    .Where(b => context
                    .UserFamilyDietFlag
                    .Where(a => family
                    .Contains(a.FamilyMember))
                    .Select(c => c.FlagId)
                    .Contains(b.FlagId));

                IEnumerable<Ingredient> ingredientList = context.Ingredient
                    .Where(b => context
                    .UserFamilyDietIngr
                    .Where(a => family
                    .Contains(a.FamilyMember))
                    .Select(c => c.IngredientId)
                    .Contains(b.IngredientId));

                IEnumerable<Desease> deseases = context.Desease
                    .Where(b => context
                    .UserFamilyDesease
                    .Where(a => family
                    .Contains(a.UserFamilyMember))
                    .Select(c => c.DeseaseId)
                    .Contains(b.DeseaseId));

                IEnumerable<Diet> diet = context.Diet
                    .Where(b => context
                    .UserFamilyDiet
                    .Where(a => family
                    .Contains(a.UserFamilyMember))
                    .Select(c => c.DietId)
                    .Contains(b.DietId));

                IEnumerable<Flag> flagList2 = context.DeseaseFlagBlacklist.Where(b => deseases.ToList().Contains(b.Desease)).Select(c => c.Flag);
                IEnumerable<Ingredient> ingredientList2 = context.DeseaseIngredientBlacklist.Where(b => deseases.ToList().Contains(b.Desease)).Select(c => c.Ingredient);

                IEnumerable<Flag> flagList3 = context.DietFlagBlacklist.Where(b => diet.ToList().Contains(b.Diet)).Select(c => c.Flag);
                IEnumerable<Ingredient> ingredientList3 = context.DietIngredientBlacklist.Where(b => diet.ToList().Contains(b.Diet)).Select(c => c.Ingredient);


            }


            context.Recipe.Where();

            return "none";
        }
        //internal-models
        internal class BlackList
        {
            internal IEnumerable<Ingredient> ingredients { get; set; }
            internal IEnumerable<Flag> flags { get; set; }
        }
    }
}
