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
    [Authorize]
    [Route("[controller]")]
    public class AdminController : ControllerBase, IAdminController
    {
        [HttpPost]
        [Route("[action]")]
        public void PostDesease(DeseaseToPost deseaseToPost)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("[action]")]
        public void PostDiet(DietToPost dietToPost)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("[action]")]
        public void PostIngredient(IngredientToPost ingredientToPost)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("[action]")]
        public void PostInstrument(InstrumentToPost instrumentToPost)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("[action]")]
        public void PostProducer(ProducerToPost producerToPost)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("[action]")]
        public void PostRecipe(RecipeSimpleToPost recipeSimpleToPost)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Route("[action]")]
        public void UpdateTransaltion(Translation translation)
        {
            throw new NotImplementedException();
        }
    }
}
