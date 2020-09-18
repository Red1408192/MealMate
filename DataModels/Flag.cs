using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class Flag
    {
        public int FlagId { get; set; }
        public Guid FlagNameId { get; set; }
        public Guid FlagDescriptionId { get; set; }
    }
}
