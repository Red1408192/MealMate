using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class Pantry
    {
        public Pantry()
        {
            PantryOvercard = new HashSet<PantryOvercard>();
        }

        public int PantryId { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PantryOvercard> PantryOvercard { get; set; }
    }
}
