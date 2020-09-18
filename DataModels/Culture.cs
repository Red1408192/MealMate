using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class Culture
    {
        public Culture()
        {
            Country = new HashSet<Country>();
            Recipe = new HashSet<Recipe>();
            UserFamily = new HashSet<UserFamily>();
        }

        public int CultureId { get; set; }
        public Guid CulNameId { get; set; }

        public virtual ICollection<Country> Country { get; set; }
        public virtual ICollection<Recipe> Recipe { get; set; }
        public virtual ICollection<UserFamily> UserFamily { get; set; }
    }
}
