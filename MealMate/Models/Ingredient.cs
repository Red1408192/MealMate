using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            InverseParent = new HashSet<Ingredient>();
            RecipeStep = new HashSet<RecipeStep>();
        }

        public int IngredientId { get; set; }
        public int? ParentId { get; set; }
        public Guid IngNameId { get; set; }
        public Guid IngDescriptionShortId { get; set; }
        public Guid IngDescriptionLongId { get; set; }
        public int? DetailTableId { get; set; }
        public int? ProductTableId { get; set; }

        public virtual Ingredient Parent { get; set; }
        public virtual ProductTable ProductTable { get; set; }
        public virtual IngredientDetailTable IngredientDetailTable { get; set; }
        public virtual ICollection<Ingredient> InverseParent { get; set; }
        public virtual ICollection<RecipeStep> RecipeStep { get; set; }
    }
}
