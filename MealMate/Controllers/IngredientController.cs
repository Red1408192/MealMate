using System;
using System.Collections.Generic;
using System.Linq;
using MealMate.Data;
using MealMate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MealMate.Controllers
{
    [Authorize] //[AllowAnonymous]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        MealMateNewContext context;

        public IngredientController(MealMateNewContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("[action]")]
        public void Post([FromBody] object request)
        {
            IngredientFull data = JsonConvert.DeserializeObject<IngredientFull>(request.ToString());

            IngredientMain ingM = data.main;
            IngredientDetail ingD = data.detail;
            IngredientProduct ingP = data.product;

            //context.Database.= Console.Write;
            ProductTable productTable = new ProductTable();
            if (ingP != null)
            {
                productTable = new ProductTable()
                {
                    ProducerId = ingP.producerId,
                    UnitType = ingP.unitType,
                    Quantity = ingP.quantity
                };

                context.Add(productTable);
                context.SaveChanges();
            }

            IngredientDetailTable detail = new IngredientDetailTable();
            if (ingD != null)
            {
                detail = new IngredientDetailTable()
                {
                    AvgLife = ingD.averageLifeTime,
                    UnitType = ingD.uType,
                    SpecificWeight = ingD.specificWheight,
                    PropWater = ingD.water,
                    PropProtein = ingD.protein,
                    PropFatTotal = ingD.fatTotal,
                    PropFatSaturated = ingD.fatSaturated,
                    PropFatUnsaturatedMono = ingD.fatUnsaturatedMono,
                    PropFatUnsaturatedPoly = ingD.fatUnsaturatedPoli,
                    PropCholesterol = ingD.cholesterol,
                    PropCarbohydrate = ingD.carbohydrate,
                    PropFiber = ingD.fiber,
                    PropCalcium = ingD.calcium,
                    PropIron = ingD.iron,
                    PropPotasium = ingD.potasium,
                    PropSodium = ingD.sodium,
                    PropVitAIu = ingD.vitA_IU,
                    PropVitARe = ingD.vitA_RE,
                    PropVitB1 = ingD.vitB_1,
                    PropVitB2 = ingD.vitB_2,
                    PropVitB3 = ingD.vitB_3,
                    PropVitC = ingD.vitC
                };

                context.Add(detail);
                context.SaveChanges();
            }

            Ingredient main = new Ingredient()
            {
                ParentId = ingM.parentId,
                ProductTableId = ingP == null ? null : (int?)productTable.ProductTableId,
                DetailTableId = ingD == null ? null : (int?)detail.DetailTableId
            };
            context.Add(main);
            context.SaveChanges();

            foreach(int fla in ingM.flags)
            {
                IngredientFlag ingFlag = new IngredientFlag()
                {
                    IngredientId = main.IngredientId,
                    FlagId = fla
                };
                context.Add(ingFlag);
                context.SaveChanges();
            }

            context.LocalizationTable
                .Where(a => a.ElementId == main.IngNameId && a.LanguageId == ingM.language)
                .FirstOrDefault().Localization = ingM.name;
            context.LocalizationTable
                .Where(a => a.ElementId == main.IngDescriptionShortId && a.LanguageId == ingM.language)
                .FirstOrDefault().Localization = ingM.descShort;
            context.LocalizationTable
                .Where(a => a.ElementId == main.IngDescriptionLongId && a.LanguageId == ingM.language)
                .FirstOrDefault().Localization = ingM.descLong;
            context.SaveChanges();
        }

        [HttpGet]
        [Route("[action]/{id:int}/{lang:int}")]
        public string Get(int id, int lang)
        {
            Ingredient query;
            List<string> queryLoc = new List<string>();
            query = context.Ingredient.Where(a => a.IngredientId == id).FirstOrDefault();

            var tokenID = this.HttpContext.User.Claims.ToList()[5].Value;

            queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == query.IngNameId && a.LanguageId == lang).FirstOrDefault().Localization);
            queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == query.IngDescriptionShortId && a.LanguageId == lang).FirstOrDefault().Localization);
            queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == query.IngDescriptionLongId && a.LanguageId == lang).FirstOrDefault().Localization);

            IngredientMain result = new IngredientMain()
            {
                parentId = (int)query.ParentId,
                ingredientId = query.IngredientId,
                language = lang,
                name = queryLoc[0],
                descShort = queryLoc[1],
                descLong = queryLoc[2]
            };
            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        [HttpGet]
        [Route("[action]/{id:int}/{lang:int}")]
        public string GetFlags(int id, int lang)
        {
            IEnumerable<string> results;
            results = context.IngredientFlag
                .Where(a => a.IngredientId == id)
                .Select(c => context.LocalizationTable
                .Where(d => d.ElementId == context.Flag
                .Where(e => e.FlagId == c.FlagId).FirstOrDefault()
                .FlagNameId && d.LanguageId == lang).FirstOrDefault().Localization);
            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        [HttpGet]
        [Route("[action]/{id:int}/{lang:int}")]
        public string GetFull(int id, int lang)
        {
            Ingredient query;
            IngredientDetailTable queryDetail;
            ProductTable queryProduct;
            IEnumerable<int> flags;

            IngredientMain resultMain;
            IngredientDetail resultDet;
            IngredientProduct resultProd;

            List<string> queryLoc = new List<string>();
            query = context.Ingredient
                .Where(a => a.IngredientId == id)
                .FirstOrDefault();

            flags = context.IngredientFlag
                .Where(a => a.IngredientId == query.IngredientId)
                .Select(b => b.FlagId);

            queryDetail = context.IngredientDetailTable
                .Where(a => a.DetailTableId == query.DetailTableId)
                .FirstOrDefault();

            queryProduct = context.ProductTable
                .Where(a => a.ProductTableId == query.ProductTableId)
                .FirstOrDefault();

            queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == query.IngNameId && a.LanguageId == lang).FirstOrDefault().Localization);
            queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == query.IngDescriptionShortId && a.LanguageId == lang).FirstOrDefault().Localization);
            queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == query.IngDescriptionLongId && a.LanguageId == lang).FirstOrDefault().Localization);

            resultMain = new IngredientMain()
            {
                parentId = query.ParentId,
                ingredientId = query.IngredientId,
                language = lang,
                name = queryLoc[0],
                descShort = queryLoc[1],
                descLong = queryLoc[2],
                flags = flags
            };
            resultDet = queryDetail == null ? new IngredientDetail() : new IngredientDetail()
            {
                averageLifeTime = queryDetail.AvgLife,
                uType = queryDetail.UnitType,
                specificWheight = (float)queryDetail.SpecificWeight,
                water = queryDetail.PropWater,
                protein = queryDetail.PropProtein,
                fatTotal = queryDetail.PropFatTotal,
                fatSaturated = queryDetail.PropFatSaturated,
                fatUnsaturatedMono = queryDetail.PropFatUnsaturatedMono,
                fatUnsaturatedPoli = queryDetail.PropFatUnsaturatedPoly,
                cholesterol = queryDetail.PropCholesterol,
                carbohydrate = queryDetail.PropCarbohydrate,
                fiber = queryDetail.PropFiber,
                calcium = queryDetail.PropCalcium,
                iron = queryDetail.PropIron,
                potasium = queryDetail.PropPotasium,
                sodium = queryDetail.PropSodium,
                vitA_IU = queryDetail.PropVitAIu,
                vitA_RE = queryDetail.PropVitARe,
                vitB_1 = queryDetail.PropVitB1,
                vitB_2 = queryDetail.PropVitB2,
                vitB_3 = queryDetail.PropVitB3,
                vitC = queryDetail.PropVitC
            };
            resultProd = queryProduct == null ? new IngredientProduct() : new IngredientProduct()
            {
                producerId = queryProduct.ProducerId,
                unitType = queryProduct.UnitType,
                quantity = (float)queryProduct.Quantity
            };

            IngredientFull result = new IngredientFull() { main = resultMain, detail = resultDet, product = resultProd };

            string test = JsonConvert.SerializeObject(result, Formatting.Indented);

            return test;
        }

        [HttpGet]
        [Route("[action]/{lang:int}")]
        public string GetAll(int lang) //DO NOT USE THIS ONE
        {
            List<Ingredient> query = new List<Ingredient>();
            List<IngredientMain> results = new List<IngredientMain>();

            query = context.Ingredient.ToList();

            foreach (var e in query)
            {
                List<string> queryLoc = new List<string>();

                queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == e.IngNameId && a.LanguageId == lang).FirstOrDefault().Localization);
                queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == e.IngDescriptionShortId && a.LanguageId == lang).FirstOrDefault().Localization);
                queryLoc.Add(context.LocalizationTable.Where(a => a.ElementId == e.IngDescriptionLongId && a.LanguageId == lang).FirstOrDefault().Localization);

                IngredientMain result = new IngredientMain()
                {
                    parentId = e.ParentId,
                    ingredientId = e.IngredientId,
                    language = lang,
                    name = queryLoc[0],
                    descShort = queryLoc[1],
                    descLong = queryLoc[2],
                    userId = 1
                };
                results.Add(result);
            }
            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        [HttpGet]
        [Route("[action]/{lang:int}")]
        public string GetList(int lang)
        {
            List<Ingredient> query = new List<Ingredient>();
            List<IngredientName> results = new List<IngredientName>();

            query = context.Ingredient.ToList();
            foreach (var e in query)
            {
                string queryLoc;

                queryLoc = context.LocalizationTable.Where(a => a.ElementId == e.IngNameId && a.LanguageId == lang).FirstOrDefault().Localization;
                IngredientName nameId = new IngredientName()
                {
                    ingId = e.IngredientId,
                    name = queryLoc
                };
                results.Add(nameId);
            }
            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        [HttpGet]
        [Route("[action]/{lang:int}")]
        public string Hierarchy(int lang)
        {

            List<Ingredient> query = context.Ingredient.ToList();
            List<IngredientHierarchy> results = new List<IngredientHierarchy>();

            foreach (var e in query)
            {
                IngredientHierarchy result = context.LocalizationTable.Where(n => (n.LanguageId == lang) && (n.ElementId == e.IngNameId)).Select(o => new IngredientHierarchy(e.IngredientId, o.Localization, e.ParentId is int ? e.ParentId : null)).FirstOrDefault();
                results.Add(result);
            }

            foreach (var e in results)
            {
                e.addChilds(results);
            }
            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        [HttpPost]
        [Route("[action]/{id:int}/{lang:int}")]
        public void UpdateLocalization(int ingId, int lang, [FromBody] object request)
        {

            NewLoc local = JsonConvert.DeserializeObject<NewLoc>(request.ToString());

            Guid name = context.Ingredient.Where(a => a.IngredientId == ingId).FirstOrDefault().IngNameId;
            Guid descShort = context.Ingredient.Where(a => a.IngredientId == ingId).FirstOrDefault().IngDescriptionShortId;
            Guid desclong = context.Ingredient.Where(a => a.IngredientId == ingId).FirstOrDefault().IngDescriptionLongId;

            context.LocalizationTable.Where(a => a.ElementId == name && a.LanguageId == lang).FirstOrDefault().Localization = local.name;
            context.LocalizationTable.Where(a => a.ElementId == descShort && a.LanguageId == lang).FirstOrDefault().Localization = local.descShort;
            context.LocalizationTable.Where(a => a.ElementId == desclong && a.LanguageId == lang).FirstOrDefault().Localization = local.descLong;

            context.SaveChanges();
        }

        [HttpPost]
        [Route("[action]/{ingId:int}")]
        public void UpdateDetail(int ingId, [FromBody] object request)
        {
            IngredientDetail ingD = JsonConvert.DeserializeObject<IngredientDetail>(request.ToString());

            if (context.Ingredient.Where(a => a.IngredientId == ingId).FirstOrDefault().DetailTableId.HasValue)
            {
                IngredientDetailTable DetailOld = context.Ingredient.Where(a => a.IngredientId == ingId).FirstOrDefault().IngredientDetailTable;
                if (true)
                {
                    DetailOld.AvgLife = ingD.averageLifeTime;
                    DetailOld.UnitType = ingD.uType;
                    DetailOld.SpecificWeight = ingD.specificWheight;
                    DetailOld.PropWater = ingD.water;
                    DetailOld.PropProtein = ingD.protein;
                    DetailOld.PropFatTotal = ingD.fatTotal;
                    DetailOld.PropFatSaturated = ingD.fatSaturated;
                    DetailOld.PropFatUnsaturatedMono = ingD.fatUnsaturatedMono;
                    DetailOld.PropFatUnsaturatedPoly = ingD.fatUnsaturatedPoli;
                    DetailOld.PropCholesterol = ingD.cholesterol;
                    DetailOld.PropCarbohydrate = ingD.carbohydrate;
                    DetailOld.PropFiber = ingD.fiber;
                    DetailOld.PropCalcium = ingD.calcium;
                    DetailOld.PropIron = ingD.iron;
                    DetailOld.PropPotasium = ingD.potasium;
                    DetailOld.PropSodium = ingD.sodium;
                    DetailOld.PropVitAIu = ingD.vitA_IU;
                    DetailOld.PropVitARe = ingD.vitA_RE;
                    DetailOld.PropVitB1 = ingD.vitB_1;
                    DetailOld.PropVitB2 = ingD.vitB_2;
                    DetailOld.PropVitB3 = ingD.vitB_3;
                    DetailOld.PropVitC = ingD.vitC;
                }

                context.SaveChanges();
            }
            else
            {
                IngredientDetailTable detailTable = new IngredientDetailTable()
                {
                    AvgLife = ingD.averageLifeTime,
                    UnitType = ingD.uType,
                    SpecificWeight = ingD.specificWheight,
                    PropWater = ingD.water,
                    PropProtein = ingD.protein,
                    PropFatTotal = ingD.fatTotal,
                    PropFatSaturated = ingD.fatSaturated,
                    PropFatUnsaturatedMono = ingD.fatUnsaturatedMono,
                    PropFatUnsaturatedPoly = ingD.fatUnsaturatedPoli,
                    PropCholesterol = ingD.cholesterol,
                    PropCarbohydrate = ingD.carbohydrate,
                    PropFiber = ingD.fiber,
                    PropCalcium = ingD.calcium,
                    PropIron = ingD.iron,
                    PropPotasium = ingD.potasium,
                    PropSodium = ingD.sodium,
                    PropVitAIu = ingD.vitA_IU,
                    PropVitARe = ingD.vitA_RE,
                    PropVitB1 = ingD.vitB_1,
                    PropVitB2 = ingD.vitB_2,
                    PropVitB3 = ingD.vitB_3,
                    PropVitC = ingD.vitC
                };

                context.Add(detailTable);
                context.SaveChanges();
            }
        }

        //internal-models

        internal class IngredientMain
        {
            [JsonProperty]
            internal int? parentId { get; set; }
            [JsonProperty]
            internal int ingredientId { get; set; }
            [JsonProperty]
            internal int language { get; set; }
            [JsonProperty]
            internal string name { get; set; }
            [JsonProperty]
            internal string descShort { get; set; }
            [JsonProperty]
            internal string descLong { get; set; }
            [JsonProperty]
            internal int userId { get; set; }
            [JsonProperty]
            internal IEnumerable<int> flags { get; set; }
        }

        internal class IngredientDetail
        {
            [JsonProperty]
            internal int averageLifeTime { get; set; }
            [JsonProperty]
            internal int uType { get; set; }
            [JsonProperty]
            internal float? specificWheight { get; set; }
            [JsonProperty]
            internal double? water { get; set; }
            [JsonProperty]
            internal double? protein { get; set; }
            [JsonProperty]
            internal double? fatTotal { get; set; }
            [JsonProperty]
            internal double? fatSaturated { get; set; }
            [JsonProperty]
            internal double? fatUnsaturatedMono { get; set; }
            [JsonProperty]
            internal double? fatUnsaturatedPoli { get; set; }
            [JsonProperty]
            internal double? cholesterol { get; set; }
            [JsonProperty]
            internal double? carbohydrate { get; set; }
            [JsonProperty]
            internal double? fiber { get; set; }
            [JsonProperty]
            internal double? calcium { get; set; }
            [JsonProperty]
            internal double? iron { get; set; }
            [JsonProperty]
            internal double? potasium { get; set; }
            [JsonProperty]
            internal double? sodium { get; set; }
            [JsonProperty]
            internal double? vitA_IU { get; set; }
            [JsonProperty]
            internal double? vitA_RE { get; set; }
            [JsonProperty]
            internal double? vitB_1 { get; set; }
            [JsonProperty]
            internal double? vitB_2 { get; set; }
            [JsonProperty]
            internal double? vitB_3 { get; set; }
            [JsonProperty]
            internal double? vitC { get; set; }
        }

        internal class IngredientProduct
        {
            [JsonProperty]
            internal int producerId { get; set; }
            [JsonProperty]
            internal int unitType { get; set; }
            [JsonProperty]
            internal float quantity { get; set; }
        }

        internal class IngredientFull
        {
            [JsonProperty]
            internal IngredientMain main { get; set; }
            [JsonProperty]
            internal IngredientDetail detail { get; set; }
            [JsonProperty]
            internal IngredientProduct product { get; set; }
        }

        internal class IngredientName
        {
            [JsonProperty]
            internal int ingId { get; set; }
            [JsonProperty]
            internal string name { get; set; }
        }

        internal class IngredientHierarchy
        {
            [JsonProperty]
            internal int id;
            [JsonProperty]
            internal int? parent;
            [JsonProperty]
            internal string name;
            [JsonProperty]
            internal ICollection<int> childs { get; set; }

            internal IngredientHierarchy(int ingredientId, string localization, int? parentId)
            {
                this.id = ingredientId;
                this.name = localization;
                this.parent = parentId;
            }

            internal void addChilds(List<IngredientHierarchy> list)
            {
                foreach (var item in list)
                {
                    if (item.parent == this.id)
                    {
                        this.childs.Add(item.id);
                    }
                }
            }
        }

        internal class NewLoc
        {
            [JsonProperty]
            internal string name { get; set; }
            [JsonProperty]
            internal string descShort { get; set; }
            [JsonProperty]
            internal string descLong { get; set; }
        }
    }
}
