using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoryModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace Comì.Repositories
{
    public class IngredientReposity
    {
        public IEnumerable<IngredientNames> GetNamesList()
        {
            return;
        }
        public Ingredient Get(int id)
        {
            return;
        }
    }
}
