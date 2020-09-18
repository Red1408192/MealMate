using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class Country
    {
        public Country()
        {
            Locations = new HashSet<Locations>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Iso { get; set; }
        public int DefLanguage { get; set; }
        public int DefCulture { get; set; }

        public virtual Culture DefCultureNavigation { get; set; }
        public virtual Language DefLanguageNavigation { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
    }
}
