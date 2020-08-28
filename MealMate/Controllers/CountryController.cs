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
            using(var context = new MealMateNewContext())
            {
                query = context.Country.Where(a => a.CountryId == id).FirstOrDefault();
            }

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
            using( var context = new MealMateNewContext())
            {
                results = context.Country.Select(a => new KeyValuePair<int, string>(a.CountryId, a.CountryName));
            }
            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        internal class CountryToSent
        {
            internal int CountryId { get; set; }
            internal string CountryName { get; set; }
            internal string Iso { get; set; }
            internal int DefLanguage { get; set; }
            internal int DefCulture { get; set; }
        }
    }
}
