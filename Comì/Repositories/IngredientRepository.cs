using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoryModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using Comì.Controllers;

namespace Comì.Repositories
{
    public class IngredientReposity : IIngredientReposity
    {
        public Ingredient Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetAll()
        {
            throw new NotImplementedException();
        }

        public IngredientFull GetFullIngredient(int id)
        {
            throw new NotImplementedException();
        }

        public IngredientDetail GetMultiProperties(IEnumerable<int> IngredientsIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IngredientNames> GetNamesList()
        {
            throw new NotImplementedException();
        }

        public IngredientDetail GetProperties(int id)
        {
            throw new NotImplementedException();
        }
    }
}
