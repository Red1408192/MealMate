using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class PantryIngredient
    {
        public int PantryOcId { get; set; }
        public int IngredientId { get; set; }
        public double Quantity { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual PantryOvercard PantryOc { get; set; }
    }
}
