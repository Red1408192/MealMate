using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class DietFlagBlacklist
    {
        public int DietId { get; set; }
        public int FlagId { get; set; }

        public virtual Diet Diet { get; set; }
        public virtual Flag Flag { get; set; }
    }
}
