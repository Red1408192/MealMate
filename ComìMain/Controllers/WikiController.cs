using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ControllerModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace ComìMain.Controllers
{
    public class WikiController : IWikiController
    {
        [HttpGet]
        [Route("[action]")]
        public DeseaseFull GetDesease(int dietId, int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public DietFull GetDiet(int dietId, int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IngredientFull GetIngredient(int recipeId, int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public InstrumentFull GetInstrument(int instrumentId, int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<string, int>> GetListDesease(int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<string, int>> GetListDiets(int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<IngredientHierarchy> GetListIngredient(int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<string, int>> GetListInstruments(int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<KeyValuePair<string, int>> GetListRecipe(int lang)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public RecipeFull GetRecipe(int recipeId, int lang)
        {
            throw new NotImplementedException();
        }
    }
}
