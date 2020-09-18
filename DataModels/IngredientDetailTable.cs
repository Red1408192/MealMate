using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class IngredientDetailTable
    {
        public int DetailTableId { get; set; }
        public int AvgLife { get; set; }
        public int UnitType { get; set; }
        public double? SpecificWeight { get; set; }
        public double? PropWater { get; set; }
        public double? PropProtein { get; set; }
        public double? PropFatTotal { get; set; }
        public double? PropFatSaturated { get; set; }
        public double? PropFatUnsaturatedMono { get; set; }
        public double? PropFatUnsaturatedPoly { get; set; }
        public double? PropCholesterol { get; set; }
        public double? PropCarbohydrate { get; set; }
        public double? PropFiber { get; set; }
        public double? PropCalcium { get; set; }
        public double? PropIron { get; set; }
        public double? PropPotasium { get; set; }
        public double? PropSodium { get; set; }
        public double? PropVitAIu { get; set; }
        public double? PropVitARe { get; set; }
        public double? PropVitB1 { get; set; }
        public double? PropVitB2 { get; set; }
        public double? PropVitB3 { get; set; }
        public double? PropVitC { get; set; }

        public virtual Ingredient DetailTable { get; set; }
        public virtual UnitType UnitTypeNavigation { get; set; }
    }
}
