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
            //JsonConvert.DeserializeObject<TTTT>(request.ToString());
        }

        [HttpGet]
        [Route("[action]/{id:int}/{lang:int}")]
        public string Get(int id, int lang)
        {
            return "none";
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
            internal string user { get; set; }
            internal int tryd { get; set; }
        }
    }
}
