﻿using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class DietIngredientBlacklist
    {
        public int DietId { get; set; }
        public int IngredientId { get; set; }

        public virtual Diet Diet { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
