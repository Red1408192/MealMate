using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class Flag
    {
        public int FlagId { get; set; }
        public Guid FlagNameId { get; set; }
        public Guid FlagDescriptionId { get; set; }
    }
}
