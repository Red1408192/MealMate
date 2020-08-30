using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class RoleClaims : IdentityRoleClaim<int>
    {
        public virtual Roles Role { get; set; }
    }
}
