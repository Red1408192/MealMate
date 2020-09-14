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

            List<Flag> flagBL = new List<Flag>();
            List<Ingredient> ingredientsBL = new List<Ingredient>();
            IEnumerable<Recipe> recipes1;


            if (parameter.famBlackList)
            {
                FamilyIntollerances intollerances = new FamilyIntollerances(user);

                flagBL = intollerances.GenerateFlags(parameter.familyMembers);
                ingredientsBL = intollerances.GenerateIngredients(parameter.familyMembers);
                
                recipes1 = context.Recipe
                                    .Where(t => context.RecipeFlag
                                        .Where(c => !flagBL
                                        .Select(b => b.FlagId)
                                        .Contains(c.FlagId))
                                    .Select(r => r.RecipeId)
                                    .Contains(t.RecipeId)
                                    && 
                                    context.RecipeSimpleIngredients
                                        .Where(c => !flagBL
                                        .Select(b => b.FlagId)
                                        .Contains(c.IngredientId))
                                    .Select(r => r.RecipeId)
                                    .Contains(t.RecipeId));
            }
            else{
                recipes1 = context.Recipe.AsQueryable();
            }
            
            if (parameter.usePantryLimits)
            {
                PantryIngredients pantryIngredients = new PantryIngredients(user);
                List<KeyValuePair<Ingredient, double>> pantryLimits = pantryIngredients.GenerateIngredients();

                PantryComparer comparer = new PantryComparer(pantryLimits);
                recipes1 = recipes1.Where(a => comparer
                                    .Compare(
                                context.RecipeSimpleIngredients
                                .Where(b => b.RecipeId == a.RecipeId)
                                .Select(d => new KeyValuePair<Ingredient, double>
                                (d.Ingredient, d.Quantity))));
            }

            return JsonConvert.SerializeObject(recipes1, Formatting.Indented);
        }
        //internal-models
        internal class BlackList
        {
            internal IEnumerable<Ingredient> ingredients { get; set; }
            internal IEnumerable<Flag> flags { get; set; }
        }
    }
}