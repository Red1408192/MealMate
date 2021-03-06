﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ControllerModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace ComìMain.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PantryController : ControllerBase, IPantryController
    {
        [HttpPost]
        [Route("[action]")]
        public void AddIngredientToPantry(int ingredient, string overcard)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<OverCard> GetCurrentPanty(int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IngredientToSent GetIngredientDetail(int id, int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<int> GetIngredientList(SearchRecPar searchPar, int lang)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("[action]")]
        public void RemoveIngredientFromPantry(int ingredient, string overcard)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Route("[action]")]
        public void UpdateQuanityOfIngredient(int ingredient, double newQuantity)
        {
            throw new NotImplementedException();
        }
    }
}

