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
    public class MealSuggesterController : ControllerBase, IMealSuggesterController
    {
        public void AddRecipeToMeal(int recipe, string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<int, string>> GetFamilyMembersList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, double>> GetIngredientUsed(int meal, int lang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetRecipeDetail(int recipe, int lang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetRecipeList(SearchRecPar searchPar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, double>> GetUnusedIngredients(int meal, int lang)
        {
            throw new NotImplementedException();
        }

        public void RemoveRecipeToMeal(int recipe, string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> UpdateFamilyMemberPresent(int meal, int familymember)
        {
            throw new NotImplementedException();
        }

        public void UpdateMealPortion(int recipe, double newQauntity)
        {
            throw new NotImplementedException();
        }
    }
}
