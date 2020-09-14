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
    [AllowAnonymous] //[AllowAnonymous]
    [Route("[controller]")]
    public class PantryController : ControllerBase
    {
        MealMateNewContext context;

        public PantryController(MealMateNewContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("[action]")]
        public void AddIngredient([FromBody] object request)
        {
            IngredientToAdd ingAdd = JsonConvert.DeserializeObject<IngredientToAdd>(request.ToString());
            if (ingAdd.overCardId == null)
            {
                PantryOvercard OC = new PantryOvercard();
                context.Add(OC);
                context.SaveChanges();
                ingAdd.overCardId = OC.PantryOvercardId;
            }

            PantryIngredient ing = new PantryIngredient()
            {
                PantryOcId = (int)ingAdd.overCardId,
                IngredientId = ingAdd.ingredientId,
                Quantity = ingAdd.quantity
            };
            context.Add(ing);
            context.SaveChanges();
        }

        [HttpGet]
        [Route("[action]/{lang:int}")]
        public string Get(int lang)
        {
            var user = this.User.Claims.ToList()[5].Value;

            IEnumerable<PantryOvercard> Currentpantry = (IEnumerable<PantryOvercard>)context.Pantry
                                                            .Where(a => a.UserId == user)
                                                            .Select(d => d
                                                            .PantryOvercard);

            PantryToSent normPantry = new PantryToSent(Currentpantry, context, lang);

            return JsonConvert.SerializeObject(normPantry, Formatting.Indented);
        }

        [HttpDelete]
        [Route("[action]/{id:int}/{lang:int}")]
        public void Delete(int id, int lang)
        {

        }

        //internal-models
        internal class IngredientToAdd
        {
            [JsonProperty]
            internal int? overCardId { get; set; }
            [JsonProperty]
            internal int ingredientId { get; set; }
            [JsonProperty]
            internal double quantity { get; set; }
        }
        internal class PantryToSent
        {
            internal IEnumerable<OverCard> OverCards { get; set; }
            internal class OverCard
            {
                internal string OvercardName { get; set; }
                private IEnumerable<OCIngredient> ingedrients {get; set;}

                internal class OCIngredient
                {
                    internal string name { get; set; }
                    internal double quantity { get; set; }

                    internal OCIngredient(string n, double q)
                    {
                        name = n;
                        quantity = q; //I can explain, i swear
                    }
                }
                internal OverCard(IEnumerable<PantryIngredient> Ingre, PantryOvercard pOC, MealMateNewContext context, int lang)
                {
                    OvercardName = pOC.Name;
                    ingedrients = Ingre.Select(a => new OCIngredient(context.LocalizationTable
                                                                            .Where(c => c.ElementId == context
                                                                            .Ingredient.Where(b => b.IngredientId == a.IngredientId)
                                                                            .FirstOrDefault()
                                                                            .IngNameId && c.LanguageId == lang)
                                                                            .FirstOrDefault().Localization, a.Quantity));
                }
            }
            internal PantryToSent(IEnumerable<PantryOvercard> pantry, MealMateNewContext context, int lang)
            {
                OverCards = pantry.Select(a => new OverCard(context.PantryIngredient
                    .Where(b => b.PantryOcId == a.PantryId), a, context, lang));
            }
        }
    }
}