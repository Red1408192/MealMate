using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoryModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace ComìMain.Repositories
{
    public class MealRepository : IMealRepository
    {
        public void AddRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Meal Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RecipeInMeals> GetRecipeList(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipeQuantity(int id, double quantity)
        {
            throw new NotImplementedException();
        }
    }
}
