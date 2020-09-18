using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class Instrument
    {
        public int InstrumentId { get; set; }
        public Guid InsNameId { get; set; }
        public Guid InsDescriptionShortId { get; set; }
        public Guid InsDescriptionLongId { get; set; }
    }
}
