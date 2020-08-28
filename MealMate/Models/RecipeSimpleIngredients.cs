using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class RecipeSimpleIngredients
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public double Quantity { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
