using System;
using System.Collections.Generic;

namespace RepositoryModels
{
    public interface IIngredientReposity
    {
        Ingredient Get(int id);
        IEnumerable<Ingredient> GetAll();
        IngredientFull GetFullIngredient(int id);
        IngredientDetail GetMultiProperties(IEnumerable<int> IngredientsIds);
        IEnumerable<IngredientNames> GetNamesList();
        IngredientDetail GetProperties(int id);
    }
}