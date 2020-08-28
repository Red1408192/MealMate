using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class RecipeStepOrder
    {
        public int RecipeStepId { get; set; }
        public int VetexRecipeStepId { get; set; }

        public virtual RecipeStep RecipeStep { get; set; }
        public virtual RecipeStep VetexRecipeStep { get; set; }
    }
}
