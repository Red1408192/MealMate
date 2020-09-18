using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class Meal
    {
        public int MealId { get; set; }
        public int UserId { get; set; }
        public DateTime PlanedFor { get; set; }
        public int Daybanch { get; set; }
    }
}
