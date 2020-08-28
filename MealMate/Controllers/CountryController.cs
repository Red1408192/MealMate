using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MealMate.Data;
using MealMate.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace MealMate.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        MealMateNewContext context;

        public CountryController(MealMateNewContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("[action]")]
        public void Post([FromBody] object request)
        {
            //not implemented
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public string Get(int id)
        {
            Country query;
            query = context.Country.Where(a => a.CountryId == id).FirstOrDefault();

            CountryToSent result = new CountryToSent()
            {
                CountryId = query.CountryId,
                CountryName = query.CountryName,
                Iso = query.Iso,
                DefCulture = query.DefCulture,
                DefLanguage = query.DefLanguage
            };

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        [HttpGet]
        [Route("[action]")]
        public string GetList()
        {
            IEnumerable<KeyValuePair<int, string>> results;
            results = context.Country.Select(a => new KeyValuePair<int, string>(a.CountryId, a.CountryName));
            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        internal class CountryToSent
        {
            [JsonProperty]
            internal int CountryId { get; set; }
            [JsonProperty]
            internal string CountryName { get; set; }
            [JsonProperty]
            internal string Iso { get; set; }
            [JsonProperty]
            internal int DefLanguage { get; set; }
            [JsonProperty]
            internal int DefCulture { get; set; }
        }
    }
}
