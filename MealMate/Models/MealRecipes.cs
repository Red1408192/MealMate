using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class MealRecipes
    {
        public int MealId { get; set; }
        public int RecipeId { get; set; }
        public int PersonsServed { get; set; }
        public double Portions { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
