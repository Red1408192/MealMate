using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MealMate.Models
{
    public partial class UserFamily
    {
        public int FamilyMember { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int CultureId { get; set; }
        public bool IsGuest { get; set; }
        public string UserId { get; set; }

        public virtual Culture Culture { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
