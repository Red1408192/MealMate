using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class Language
    {
        public Language()
        {
            Country = new HashSet<Country>();
        }

        public int LanguageId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Country> Country { get; set; }
    }
}
