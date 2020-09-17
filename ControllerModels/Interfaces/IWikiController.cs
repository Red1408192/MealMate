using System.Collections.Generic;
using ControllerModels;

namespace ControllerModels
{
    public interface IWikiController
    {
        DeseaseFull GetDesease(int dietId, int lang);
        DietFull GetDiet(int dietId, int lang);
        IngredientFull GetIngredient(int recipeId, int lang);
        InstrumentFull GetInstrument(int instrumentId, int lang);
        RecipeFull GetRecipe(int recipeId, int lang);
        IEnumerable<KeyValuePair<string, int>> GetListDesease(int lang);
        IEnumerable<KeyValuePair<string, int>> GetListDiets(int lang);
        IEnumerable<IngredientHierarchy> GetListIngredient(int lang);
        IEnumerable<KeyValuePair<string, int>> GetListInstruments(int lang);
        IEnumerable<KeyValuePair<string, int>> GetListRecipe(int lang);
    }
}