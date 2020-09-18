using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class RecipeStepInstrument
    {
        public int RecipeStepId { get; set; }
        public int RecipeStepInstrument1 { get; set; }

        public virtual RecipeStep RecipeStep { get; set; }
        public virtual Instrument RecipeStepInstrument1Navigation { get; set; }
    }
}
