using RepositoryModels;
using System.Collections;
using System.Collections.Generic;

namespace RepositoryModels
{
    public interface IMealRepository
    {
        void Delete(int id); //it actually create a new standard meal (we do not delete anything in here)
        Meal Get(int id);
        IEnumerable<RecipeInMeals> GetRecipeList(int id);
        void RemoveRecipe(int id);
        void AddRecipe(int id);
        void UpdateRecipeQuantity(int id, double quantity);
    }
}