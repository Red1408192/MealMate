using ControllerModels;
using System.Collections.Generic;

namespace ControllerModels
{
    public interface IMealSuggesterController
    {
        IEnumerable<KeyValuePair<string, double>> GetIngredientUsed(int meal, int lang);
        IEnumerable<Recipe> GetRecipeDetail(int recipe, int lang);
        IEnumerable<int> GetRecipeList(SearchRecPar searchPar);
        IEnumerable<KeyValuePair<string, double>> GetUnusedIngredients(int meal, int lang);
        void AddRecipeToMeal(int recipe, string user);
        void RemoveRecipeToMeal(int recipe, string user);
        IEnumerable<KeyValuePair<int, string>> GetFamilyMembersList();
        IEnumerable<int> UpdateFamilyMemberPresent(int meal, int familymember); // Return the list of recipe violleting the BlackList
        void UpdateMealPortion(int recipe, double newQauntity);
    }
}