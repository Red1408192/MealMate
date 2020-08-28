using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class RecipeSimpleInstrument
    {
        public int RecipeId { get; set; }
        public int InstrumentId { get; set; }

        public virtual Instrument Instrument { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
