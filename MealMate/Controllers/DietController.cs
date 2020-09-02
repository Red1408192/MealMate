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
    public class DietController : ControllerBase
    {
        MealMateNewContext context;

        public DietController(MealMateNewContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("[action]")]
        public void Post([FromBody] object request)
        {
            DietToRead die = JsonConvert.DeserializeObject<DietToRead>(request.ToString());

            Diet diet = new Diet();
            context.Add(diet);
            context.SaveChanges();

            context.LocalizationTable
                .Where(a => a.ElementId == diet.DietNameId && a.LanguageId == die.lang)
                .FirstOrDefault().Localization = die.name;
            context.SaveChanges();

            foreach (int ing in die.ingres)
            {
                DietIngredientBlacklist dietIngredientBlacklist = new DietIngredientBlacklist()
                {
                    DietId = diet.DietId,
                    IngredientId = ing
                };
                context.Add(dietIngredientBlacklist);
                context.SaveChanges();
            }

            foreach (int fla in die.flags)
            {
                DietFlagBlacklist dietFlagBlacklist = new DietFlagBlacklist()
                {
                    DietId = diet.DietId,
                    FlagId = fla
                };
                context.Add(dietFlagBlacklist);
                context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("[action]/{id:int}/{lang:int}")]
        public string Get(int id, int lang)
        {
            string name;
            IEnumerable<int> ing;
            IEnumerable<int> fla;

            Diet query = context.Diet
                .Where(a => a.DietId == id).FirstOrDefault();

            name = context.LocalizationTable
                .Where(a => a.ElementId == query.DietNameId && a.LanguageId == lang)
                .FirstOrDefault().Localization;

            ing = context.DietIngredientBlacklist
                .Where(a => a.DietId == id).Select(c => c.IngredientId);
            fla = context.DietFlagBlacklist
                .Where(a => a.DietId == id).Select(c => c.FlagId);

            DietToSent dietToSent = new DietToSent()
            {
                name = name,
                ingres = ing,
                flags = fla
            };

            return JsonConvert.SerializeObject(dietToSent, Formatting.Indented);
        }

        [HttpGet]
        [Route("[action]/{lang:int}")]
        public string GetList(int lang)
        {
            IEnumerable<KeyValuePair<int, string>> results;

            results = context.Diet.Select(a => new KeyValuePair<int, string>(a.DietId,
                context.LocalizationTable
                .Where(c => c.ElementId == a.DietNameId && c.LanguageId == lang)
                .FirstOrDefault().Localization));
            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        [HttpDelete]
        [Route("[action]/{id:int}/{lang:int}")]
        public void Delete(int id, int lang)
        {
            //to do
        }

        //internal-models
        internal class DietToRead
        {
            [JsonProperty]
            internal int lang { get; set; }
            [JsonProperty]
            internal string name { get; set; }
            [JsonProperty]
            internal IEnumerable<int> ingres { get; set; }
            [JsonProperty]
            internal IEnumerable<int> flags { get; set; }
        }

        internal class DietToSent
        {
            [JsonProperty]
            internal string name { get; set; }
            [JsonProperty]
            internal IEnumerable<int> ingres { get; set; }
            [JsonProperty]
            internal IEnumerable<int> flags { get; set; }
        }
    }
}
