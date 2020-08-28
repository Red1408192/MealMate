using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class Pantry
    {
        public Pantry()
        {
            PantryOvercard = new HashSet<PantryOvercard>();
        }

        public int PantryId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PantryOvercard> PantryOvercard { get; set; }
    }
}
