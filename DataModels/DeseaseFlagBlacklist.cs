using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class DeseaseFlagBlacklist
    {
        public int DeseaseId { get; set; }
        public int FlagId { get; set; }

        public virtual Desease Desease { get; set; }
        public virtual Flag Flag { get; set; }
    }
}
