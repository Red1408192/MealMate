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
    public class RecipeRepository : IRecipesRepository
    {
        public Recipe Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetFiltered(string user, string searchbarInput, IEnumerable<int> familyMembers, bool famBlackList, bool usePantryLimits)
        {
            throw new NotImplementedException();
        }

        public RecipeFull GetFull(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, double>> GetIngredientUsed(IEnumerable<int> recipeList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RecipeNames> GetNamesList()
        {
            throw new NotImplementedException();
        }
    }
}
