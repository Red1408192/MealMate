using RepositoryModels;
using System.Collections.Generic;

namespace Comì.Repositories
{
    public interface IRecipesRepository
    {
        Recipe Get(int id);
        IEnumerable<int> GetFiltered(string user, string searchbarInput, IEnumerable<int> familyMembers, bool famBlackList, bool usePantryLimits);
        RecipeFull GetFull(int id);
        IEnumerable<KeyValuePair<string, double>> GetIngredientUsed(IEnumerable<int> recipeList);
        IEnumerable<RecipeNames> GetNamesList();
    }
}