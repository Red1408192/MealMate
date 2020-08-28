using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class RecipeStepNote
    {
        public int RecipeStepId { get; set; }
        public int NoteId { get; set; }

        public virtual Note Note { get; set; }
        public virtual RecipeStep RecipeStep { get; set; }
    }
}
