using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class ProductLocation
    {
        public int ProductId { get; set; }
        public int LocationId { get; set; }

        public virtual Locations Location { get; set; }
        public virtual Ingredient Product { get; set; }
    }
}
