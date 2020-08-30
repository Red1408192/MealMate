using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MealMate.Models
{
    public partial class Pantry
    {
        public Pantry()
        {
            PantryOvercard = new HashSet<PantryOvercard>();
        }

        public int PantryId { get; set; }
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual ICollection<PantryOvercard> PantryOvercard { get; set; }
    }
}
