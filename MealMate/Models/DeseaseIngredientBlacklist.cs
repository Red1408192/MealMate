using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class DeseaseIngredientBlacklist
    {
        public int? DeseaseId { get; set; }
        public int IngredientId { get; set; }

        public virtual Desease Desease { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
