using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class RecipeStepFlag
    {
        public int RecipeStepId { get; set; }
        public int FlagId { get; set; }

        public virtual Flag Flag { get; set; }
        public virtual RecipeStep RecipeStep { get; set; }
    }
}
