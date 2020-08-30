using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MealMate.Models
{
    public partial class UserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }
    }
}
