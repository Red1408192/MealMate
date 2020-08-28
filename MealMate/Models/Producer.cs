using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class Producer
    {
        public Producer()
        {
            ProductTable = new HashSet<ProductTable>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int? MainCountry { get; set; }

        public virtual ICollection<ProductTable> ProductTable { get; set; }
    }
}
