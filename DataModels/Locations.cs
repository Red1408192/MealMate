using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class Locations
    {
        public int LocationId { get; set; }
        public int CountryId { get; set; }
        public string ZipCode { get; set; }

        public virtual Country Country { get; set; }
    }
}
