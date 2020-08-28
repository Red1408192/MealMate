using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class UserFamilyDietFlag
    {
        public int FamilyMemberId { get; set; }
        public int FlagId { get; set; }

        public virtual UserFamily FamilyMember { get; set; }
        public virtual Flag Flag { get; set; }
    }
}
