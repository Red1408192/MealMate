using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class RecipeStep
    {
        public RecipeStep()
        {
            RecipeStepOrderVetexRecipeStep = new HashSet<RecipeStepOrder>();
        }

        public int StepId { get; set; }
        public int RecipeId { get; set; }
        public int ActionId { get; set; }
        public short? TimeCook { get; set; }
        public short? TimeWait { get; set; }
        public int? OutputIngredientId { get; set; }

        public virtual Action Action { get; set; }
        public virtual Ingredient OutputIngredient { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual RecipeStepOrder RecipeStepOrderRecipeStep { get; set; }
        public virtual ICollection<RecipeStepOrder> RecipeStepOrderVetexRecipeStep { get; set; }
    }
}
