using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class RecipeFlag
    {
        public int RecipeId { get; set; }
        public int FlagId { get; set; }

        public virtual Flag Flag { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
