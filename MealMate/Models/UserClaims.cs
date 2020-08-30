using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MealMate.Models
{
    public partial class UserClaims : IdentityUserClaim<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
