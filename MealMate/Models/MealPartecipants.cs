using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class MealPartecipants
    {
        public int MealId { get; set; }
        public int UserId { get; set; }
        public int FamilyMemberId { get; set; }

        public virtual Meal Meal { get; set; }
    }
}
