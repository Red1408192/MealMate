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
    public class FlagController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public void Post([FromBody] object request)
        {
            FlagToPost flag = JsonConvert.DeserializeObject<FlagToPost>(request.ToString());

            using(var context = new MealMateNewContext())
            {
                Flag flag1 = new Flag();

                context.Add(flag1);
                context.SaveChanges();

                context.LocalizationTable
                    .Where(a => a.ElementId == flag1.FlagNameId && a.LanguageId == flag.lang)
                    .FirstOrDefault().Localization = flag.name;
                context.LocalizationTable
                    .Where(a => a.ElementId == flag1.FlagDescriptionId && a.LanguageId == flag.lang)
                    .FirstOrDefault().Localization = flag.description;
                context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("[action]/{id:int}/{lang:int}")]
        public string Get(int id, int lang)
        {
            KeyValuePair<string, string> result;
            using (var context = new MealMateNewContext())
            {
                Flag query = context.Flag
                    .Where(a => a.FlagId == id)
                    .FirstOrDefault();

                var name = context.LocalizationTable
                    .Where(c => c.ElementId == query.FlagNameId && c.LanguageId == lang)
                    .FirstOrDefault().Localization;

                var desc = context.LocalizationTable
                    .Where(c => c.ElementId == query.FlagDescriptionId && c.LanguageId == lang)
                    .FirstOrDefault().Localization;

                result = new KeyValuePair<string, string>(name, desc);
            };
            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        [HttpGet]
        [Route("[action]/{lang:int}")]
        public string GetList(int lang)
        {
            IEnumerable<KeyValuePair<int, string>> results;
            using (var context = new MealMateNewContext())
            {
                results = context.Flag
                    .Select(a => new KeyValuePair<int, string>(a.FlagId,
                    context.LocalizationTable
                    .Where(c => c.ElementId == a.FlagNameId && c.LanguageId == lang)
                    .FirstOrDefault().Localization));
            }
            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public void Delete(int id)
        {

        }

        //internal-models

        internal class FlagToPost
        {
            internal int lang;
            internal string name;
            internal string description;
        }
    }
}
