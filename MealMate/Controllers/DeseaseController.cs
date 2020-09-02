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
    public class DeseaseController : ControllerBase
    {
        MealMateNewContext context;

        public DeseaseController(MealMateNewContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("[action]")]
        public void Post([FromBody] object request)
        {
            DeseaseToRead des = JsonConvert.DeserializeObject<DeseaseToRead>(request.ToString());
            
            Desease desease = new Desease();
            context.Add(desease);
            context.SaveChanges();

            context.LocalizationTable
                .Where(a => a.ElementId == desease.DeseaseNameId && a.LanguageId == des.lang)
                .FirstOrDefault().Localization = des.name;
            context.SaveChanges();

            foreach (int ing in des.ingres)
            {
                DeseaseIngredientBlacklist deseaseIngredientBlacklist = new DeseaseIngredientBlacklist()
                {
                    DeseaseId = desease.DeseaseId,
                    IngredientId = ing
                };
                context.Add(deseaseIngredientBlacklist);
                context.SaveChanges();
            }

            foreach (int fla in des.flags)
            {
                DeseaseFlagBlacklist deseaseFlagBlacklist = new DeseaseFlagBlacklist()
                {
                    DeseaseId = desease.DeseaseId,
                    FlagId = fla
                };
                context.Add(deseaseFlagBlacklist);
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

            Desease query = context.Desease
                .Where(a => a.DeseaseId == id).FirstOrDefault();

            name = context.LocalizationTable
                .Where(a => a.ElementId == query.DeseaseNameId && a.LanguageId == lang)
                .FirstOrDefault().Localization;

            ing = context.DeseaseIngredientBlacklist
                .Where(a => a.DeseaseId == id).Select(c => c.IngredientId);
            fla = context.DeseaseFlagBlacklist
                .Where(a => a.DeseaseId == id).Select(c => c.FlagId);

            DeseaseToSent deseaseToSent = new DeseaseToSent()
            {
                name = name,
                ingres = ing,
                flags = fla
            };

            return JsonConvert.SerializeObject(deseaseToSent, Formatting.Indented);
        }

        [HttpGet]
        [Route("[action]/{lang:int}")]
        public string GetList(int lang)
        {
            IEnumerable<KeyValuePair<int, string>> results;

            results = context.Desease.Select(a => new KeyValuePair<int, string>(a.DeseaseId,
                context.LocalizationTable
                .Where(c => c.ElementId == a.DeseaseNameId && c.LanguageId == lang)
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
        internal class DeseaseToRead
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

        internal class DeseaseToSent
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