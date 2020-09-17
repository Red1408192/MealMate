using ControllerModels;
using System.Collections.Generic;

namespace ControllerModels
{
    public interface IPantryController
    {
        IEnumerable<OverCard> GetCurrentPanty(int lang);
        IngredientToSent GetIngredientDetail(int id, int lang);
        IEnumerable<int> GetIngredientList(SearchRecPar searchPar, int lang);
        void AddIngredientToPantry(int ingredient, string overcard);
        void RemoveIngredientFromPantry(int ingredient, string overcard);
        void UpdateQuanityOfIngredient(int ingredient, double newQuantity);
    }
}