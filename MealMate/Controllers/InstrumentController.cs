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
    public class InstrumentController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public void Post([FromBody] object request)
        {
            instrumnetToRead ins = JsonConvert.DeserializeObject<instrumnetToRead>(request.ToString());

            using(var context = new MealMateNewContext())
            {
                Instrument instrument = new Instrument();
                context.Add(instrument);
                context.SaveChanges();

                context.LocalizationTable
                    .Where(a => a.ElementId == instrument.InsNameId && a.LanguageId == ins.language)
                    .FirstOrDefault().Localization = ins.name;
                context.LocalizationTable
                    .Where(a => a.ElementId == instrument.InsDescriptionShortId && a.LanguageId == ins.language)
                    .FirstOrDefault().Localization = ins.descShort;
                context.LocalizationTable
                    .Where(a => a.ElementId == instrument.InsDescriptionLongId && a.LanguageId == ins.language)
                    .FirstOrDefault().Localization = ins.descLong;
                context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("[action]/{id:int}/{lang:int}")]
        public string Get(int id, int lang)
        {
            Instrument query;
            List<string> queryLoc = new List<string>();

            using(var context = new MealMateNewContext())
            {
                query = context.Instrument.Where(a => a.InstrumentId == id).FirstOrDefault();

                queryLoc.Add(context.LocalizationTable
                    .Where(a => a.ElementId == query.InsNameId && a.LanguageId == lang)
                        .FirstOrDefault().Localization);

                queryLoc.Add(context.LocalizationTable
                    .Where(a => a.ElementId == query.InsDescriptionShortId && a.LanguageId == lang)
                        .FirstOrDefault().Localization);

                queryLoc.Add(context.LocalizationTable
                    .Where(a => a.ElementId == query.InsDescriptionLongId && a.LanguageId == lang)
                        .FirstOrDefault().Localization);
            }

            instrumnetToRead result = new instrumnetToRead()
            {
                language = lang,
                name = queryLoc[0],
                descShort = queryLoc[1],
                descLong = queryLoc[2]
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
                results = context.Instrument
                    .Select(a => new KeyValuePair<int, string> (a.InstrumentId,
                    context.LocalizationTable.Where(c => c.ElementId == a.InsNameId && c.LanguageId == lang)
                    .FirstOrDefault().Localization));
            }

            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        internal class instrumnetToRead
        {
            internal int language;
            internal string name;
            internal string descShort;
            internal string descLong;
        }

        internal class instrumentNames
        {
            internal int id;
            internal string name;
        }
    }
}
