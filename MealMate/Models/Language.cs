using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class Language
    {
        public Language()
        {
            Country = new HashSet<Country>();
            User = new HashSet<User>();
        }

        public int LanguageId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Country> Country { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
