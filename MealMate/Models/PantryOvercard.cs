using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class PantryOvercard
    {
        public int PantryOvercardId { get; set; }
        public int PantryId { get; set; }
        public string Name { get; set; }

        public virtual Pantry Pantry { get; set; }
    }
}
