﻿using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class IngredientFlag
    {
        public int IngredientId { get; set; }
        public int FlagId { get; set; }

        public virtual Flag Flag { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
