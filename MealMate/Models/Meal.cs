using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class Meal
    {
        public int MealId { get; set; }
        public int UserId { get; set; }
        public DateTime PlanedFor { get; set; }
        public int Daybanch { get; set; }

        public virtual User User { get; set; }
    }
}
