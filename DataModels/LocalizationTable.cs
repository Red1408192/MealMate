using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class LocalizationTable
    {
        public Guid ElementId { get; set; }
        public int LanguageId { get; set; }
        public string Localization { get; set; }

        public virtual Language Language { get; set; }
    }
}
