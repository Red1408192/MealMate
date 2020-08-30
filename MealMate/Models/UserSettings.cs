﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MealMate.Models
{
    public partial class UserSettings
    {
        public int LanguageId { get; set; }
        public bool? IsPublic { get; set; }
        public int DefCountryId { get; set; }
        public bool? NewRecSugg { get; set; }
        public bool? ExpAllarm { get; set; }
        public bool NoPantry { get; set; }
        public string UserId { get; set; }

        public virtual Language Language { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
