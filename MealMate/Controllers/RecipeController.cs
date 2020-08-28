using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MealMate.Data;
using MealMate.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace MealMate.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public void PostSimple([FromBody] object request)
        {
            RecipeSimple recipe = JsonConvert.DeserializeObject<RecipeSimple>(request.ToString());
            using (var context = new MealMateNewContext())
            {
                Recipe recipeToUpload = new Recipe()
                {
                    CreatedByUser = recipe.createdBy,
                    IsPublic = recipe.isPublic,
                    DifficultyRating = recipe.difRating,
                    TotalTimeCook = recipe.prepTime,
                    TotalTimeWait = recipe.waitTime,
                    CultureId = recipe.culture
                };
                context.Add(recipeToUpload);
                context.SaveChanges();

                foreach (var rIng in recipe.recipeIngredients)
                {
                    RecipeSimpleIngredients rSIng = new RecipeSimpleIngredients()
                    {
                        RecipeId = recipeToUpload.RecipeId,
                        IngredientId = rIng.Key,
                        Quantity = rIng.Value
                    };
                    context.Add(rSIng);
                    context.SaveChanges();
                }

                foreach (var rIns in recipe.recipeInstruments)
                {
                    RecipeSimpleInstrument rSIns = new RecipeSimpleInstrument()
                    {
                        RecipeId = recipeToUpload.RecipeId,
                        InstrumentId = rIns
                    };
                    context.Add(rSIns);
                    context.SaveChanges();
                }

                context.LocalizationTable
                    .Where(a => a.ElementId == recipeToUpload.RecNameId && a.LanguageId == recipe.lang)
                    .FirstOrDefault().Localization = recipe.name;
                context.LocalizationTable
                    .Where(a => a.ElementId == recipeToUpload.RecDescriptionShortId && a.LanguageId == recipe.lang)
                    .FirstOrDefault().Localization = recipe.descShort;
                context.LocalizationTable
                    .Where(a => a.ElementId == recipeToUpload.RecDescriptionLongId && a.LanguageId == recipe.lang)
                    .FirstOrDefault().Localization = recipe.descLong;
                context.SaveChanges();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public void PostFull([FromBody] object request)
        {
            //to Do
        }

        [HttpGet]
        [Route("[action]/{id:int}/{lang:int}")]
        public string Get(int id, int lang)
        {
            Recipe query;
            List<string> queryLoc = new List<string>();
            IEnumerable<KeyValuePair<int, float>> queryIngs;
            IEnumerable<int> queryIns;

            using (var context = new MealMateNewContext())
            {
                query = context.Recipe.Where(a => a.RecipeId == id).FirstOrDefault();

                queryIngs = context.RecipeSimpleIngredients
                    .Where(a => a.RecipeId == query.RecipeId)
                    .Select(a => new KeyValuePair<int, float>(a.IngredientId, (float)a.Quantity));

                queryIns = context.RecipeSimpleInstrument.Where(a => a.RecipeId == query.RecipeId).Select(a => a.InstrumentId);

                queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == query.RecNameId).FirstOrDefault().Localization);
                queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == query.RecDescriptionShortId).FirstOrDefault().Localization);
                queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == query.RecDescriptionLongId).FirstOrDefault().Localization);
            }

            RecipeSimple result = new RecipeSimple()
            {
                lang = lang,
                name = queryLoc[0],
                descShort = queryLoc[1],
                descLong = queryLoc[2],
                createdBy = query.CreatedByUser,
                isPublic = query.IsPublic ??= false,
                difRating = query.DifficultyRating,
                waitTime = query.TotalTimeWait,
                prepTime = query.TotalTimeCook,
                culture = query.CultureId,
                recipeIngredients = queryIngs,
                recipeInstruments = queryIns
            };

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        [HttpGet]
        [Route("[action]/{lang:int}")]
        public string GetList(int lang)
        {
            IEnumerable<KeyValuePair<int, string>> results;
            using (var context = new MealMateNewContext())
            {
                results = context.Recipe
                    .Select(a => new KeyValuePair<int, string>(a.RecipeId,
                    context.LocalizationTable.Where(c => c.ElementId == a.RecNameId && c.LanguageId == lang).FirstOrDefault()
                    .Localization));
            }
            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        internal class recipeFull
        {
            internal int lang { get; set; }
            internal string name { get; set; }
            internal string descShort { get; set; }
            internal string descLong { get; set; }
            internal int createdBy { get; set; }
            internal bool isPublic { get; set; }
            internal short difRating { get; set; }
            internal short waitTime { get; set; }
            internal short prepTime { get; set; }
            internal int colture { get; set; }
            internal IEnumerable<RecipeStepFull> recipeSteps { get; set; }
        }

        internal class RecipeStepFull
        {
            internal int action { get; set; }
            internal short? timeCook { get; set; }
            internal short? timeWait { get; set; }
            internal int? outputIngredientOutput { get; set; }
            internal IEnumerable<KeyValuePair<int, float>> stepIngredients { get; set; }
            internal IEnumerable<int> instruments { get; set; }
        }

        internal class RecipeSimple
        {
            internal int lang { get; set; }
            internal string name { get; set; }
            internal string descShort { get; set; }
            internal string descLong { get; set; }
            internal int createdBy { get; set; }
            internal bool isPublic { get; set; }
            internal short difRating { get; set; }
            internal short? waitTime { get; set; }
            internal short? prepTime { get; set; }
            internal int? culture { get; set; }
            internal IEnumerable<KeyValuePair<int, float>> recipeIngredients { get; set; }
            internal IEnumerable<int> recipeInstruments { get; set; }
        }

        internal class RecipeName
        {
            internal int recId { get; set; }
            internal string name { get; set; }
        }
    }
}
