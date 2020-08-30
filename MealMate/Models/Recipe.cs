using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeRating = new HashSet<RecipeRating>();
            RecipeStep = new HashSet<RecipeStep>();
        }

        public int RecipeId { get; set; }
        public Guid RecNameId { get; set; }
        public Guid RecDescriptionShortId { get; set; }
        public Guid RecDescriptionLongId { get; set; }
        public DateTime CreatedInDate { get; set; }
        public int CreatedByUser { get; set; }
        public bool? IsPublic { get; set; }
        public short DifficultyRating { get; set; }
        public short? TotalTimeCook { get; set; }
        public short? TotalTimeWait { get; set; }
        public int? CultureId { get; set; }

        public virtual Culture Culture { get; set; }
        public virtual ICollection<RecipeRating> RecipeRating { get; set; }
        public virtual ICollection<RecipeStep> RecipeStep { get; set; }
    }
}
