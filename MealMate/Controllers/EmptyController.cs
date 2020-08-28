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
    public class EmptyController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public void Post([FromBody] object request)
        {
            //JsonConvert.DeserializeObject<TTTT>(request.ToString());
        }

        [HttpGet]
        [Route("[action]/{id:int}/{lang:int}")]
        public string Get(int id, int lang)
        {
            
        }

        [HttpDelete]
        [Route("[action]/{id:int}/{lang:int}")]
        public void Delete(int id, int lang)
        {

        }

        //internal-models
    }
}
