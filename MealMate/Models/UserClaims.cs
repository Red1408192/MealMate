using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MealMate.Models
{
    public partial class UserClaims
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual IdentityUser User { get; set; }
    }
}
