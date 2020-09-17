using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ControllerModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace Comì.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PantryController : ControllerBase, IPantryController
    {
        public void AddIngredientToPantry(int ingredient, string overcard)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OverCard> GetCurrentPanty(int lang)
        {
            throw new NotImplementedException();
        }

        public IngredientToSent GetIngredientDetail(int id, int lang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetIngredientList(SearchRecPar searchPar, int lang)
        {
            throw new NotImplementedException();
        }

        public void RemoveIngredientFromPantry(int ingredient, string overcard)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuanityOfIngredient(int ingredient, double newQuantity)
        {
            throw new NotImplementedException();
        }
    }
}

