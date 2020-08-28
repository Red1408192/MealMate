using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using MealMate.Models;
using MealMate.Data;

namespace MealMate.Controllers
{
    [Route("[Controller]")]
    public class Unit : ControllerBase
    {
        [HttpGet]
        [Route("[action]/")]
        public string GetList() //DO NOT USE THIS ONE
        {
            List<UnitType> query = new List<UnitType>();
            using (var context = new MealMateNewContext())
            {
                query = context.UnitType.ToList();
            }
            return JsonConvert.SerializeObject(query, Formatting.Indented);
        }
    }
}
