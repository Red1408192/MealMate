using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class UserSettings
    {
        public int UserId { get; set; }
        public int LanguageId { get; set; }
        public bool? IsPublic { get; set; }
        public int DefCountryId { get; set; }
        public bool? NewRecSugg { get; set; }
        public bool? ExpAllarm { get; set; }
        public bool NoPantry { get; set; }

        public virtual Language Language { get; set; }
        public virtual User User { get; set; }
    }
}
