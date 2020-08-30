using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class RecipeRating
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public bool? Liked { get; set; }
        public string Comment { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
