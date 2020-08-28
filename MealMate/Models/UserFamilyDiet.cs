using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class UserFamilyDiet
    {
        public int UserFamilyMemberId { get; set; }
        public int DietId { get; set; }

        public virtual Diet Diet { get; set; }
        public virtual UserFamily UserFamilyMember { get; set; }
    }
}
