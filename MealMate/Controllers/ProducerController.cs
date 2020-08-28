using MealMate.Models;
using MealMate.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealMate.Controllers
{
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public void Post([FromBody] object request)
        {
            ProducerToSend prod = JsonConvert.DeserializeObject<ProducerToSend>(request.ToString());

            using(var context = new MealMateNewContext())
            {
                Producer producer = new Producer()
                {
                    BrandName = prod.name,
                    MainCountry = prod.Country
                };
                context.Add(producer);
                context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("[action]")]
        public string GetList()
        {
            IEnumerable<KeyValuePair<int, string>> query;
            using (var context = new MealMateNewContext())
            {
                query = context.Producer.Select(a =>
                new KeyValuePair<int, string>(a.BrandId, a.BrandName));
            }
            return JsonConvert.SerializeObject(query, Formatting.Indented);
        }

        internal class ProducerToSend
        {
            internal string name;
            internal int? Country;
        }
    }
}
