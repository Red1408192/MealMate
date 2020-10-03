using System;
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
    public class MealSuggesterController : ControllerBase, IMealSuggesterController
    {
        [HttpPost]
        [Route("[action]")]
        public void AddRecipeToMeal(int recipe, string user)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<int, string>> GetFamilyMembersList()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<string, double>> GetIngredientUsed(int meal, int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Recipe> GetRecipeDetail(int recipe, int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<int> GetRecipeList(SearchRecPar searchPar)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<string, double>> GetUnusedIngredients(int meal, int lang)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("[action]")]
        public void RemoveRecipeToMeal(int recipe, string user)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Route("[action]")]
        public IEnumerable<int> UpdateFamilyMemberPresent(int meal, int familymember)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Route("[action]")]
        public void UpdateMealPortion(int recipe, double newQauntity)
        {
            throw new NotImplementedException();
        }
    }
}
