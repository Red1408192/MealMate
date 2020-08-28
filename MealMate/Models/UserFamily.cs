using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class UserFamily
    {
        public int UserId { get; set; }
        public int FamilyMember { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int CultureId { get; set; }
        public bool IsGuest { get; set; }

        public virtual Culture Culture { get; set; }
        public virtual User User { get; set; }
    }
}
