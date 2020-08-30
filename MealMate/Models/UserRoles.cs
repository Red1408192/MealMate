using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MealMate.Models
{
    public partial class UserRoles : IdentityUserRole<string>
    {
        public virtual Roles Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
