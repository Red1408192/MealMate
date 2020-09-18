using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class RecipeStepIngredient
    {
        public int RecipeStepId { get; set; }
        public int IngredientId { get; set; }
        public double IngredientAmount { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual RecipeStep RecipeStep { get; set; }
    }
}
