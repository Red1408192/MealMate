using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MealMate.Models
{
    public partial class UserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
