using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class UnitType
    {
        public UnitType()
        {
            IngredientDetailTable = new HashSet<IngredientDetailTable>();
            ProductTable = new HashSet<ProductTable>();
        }

        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<IngredientDetailTable> IngredientDetailTable { get; set; }
        public virtual ICollection<ProductTable> ProductTable { get; set; }
    }
}
