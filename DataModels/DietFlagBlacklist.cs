using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class DietFlagBlacklist
    {
        public int DietId { get; set; }
        public int FlagId { get; set; }

        public virtual Diet Diet { get; set; }
        public virtual Flag Flag { get; set; }
    }
}
