using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class ProductTable
    {
        public ProductTable()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public int ProductTableId { get; set; }
        public int ProducerId { get; set; }
        public int UnitType { get; set; }
        public double Quantity { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual UnitType UnitTypeNavigation { get; set; }
        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}
