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
    [Authorize]
    [Route("[controller]")]
    public class CultureController : ControllerBase
    {
        MealMateNewContext context;

        public CultureController(MealMateNewContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("[action]")]
        public void Post([FromBody] object request)
        {
            cultureToSend cult = JsonConvert.DeserializeObject<cultureToSend>(request.ToString());

            Culture culture = new Culture();
            context.Add(culture);
            context.SaveChanges();

            context.LocalizationTable.Where(a => a.ElementId == culture.CulNameId && a.LanguageId == cult.lang).FirstOrDefault().Localization = cult.name;
            context.SaveChanges();
        }

        [HttpGet]
        [Route("[action]/{lang:int}")]
        public string GetList(int lang)
        {
            IEnumerable<KeyValuePair<int, string>> results;

            results = context.Culture
                .Select(a => new KeyValuePair<int, string>(a.CultureId,
                context.LocalizationTable.Where(c => c.ElementId == a.CulNameId && c.LanguageId == lang)
                .FirstOrDefault().Localization));

            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        internal class cultureToSend
        {
            [JsonProperty]
            internal int lang;
            [JsonProperty]
            internal int id;
            [JsonProperty]
            internal string name;
        }
    }
}
