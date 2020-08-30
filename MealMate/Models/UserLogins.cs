using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MealMate.Models
{
    public partial class UserLogins : IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
