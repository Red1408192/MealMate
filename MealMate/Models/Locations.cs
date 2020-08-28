using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class Locations
    {
        public Locations()
        {
            User = new HashSet<User>();
        }

        public int LocationId { get; set; }
        public int CountryId { get; set; }
        public string ZipCode { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
