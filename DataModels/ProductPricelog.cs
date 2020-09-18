using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class ProductPricelog
    {
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int Country { get; set; }
        public DateTime Date { get; set; }

        public virtual Country CountryNavigation { get; set; }
        public virtual ProductTable Product { get; set; }
    }
}
