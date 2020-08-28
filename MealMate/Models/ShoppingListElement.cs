using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class ShoppingListElement
    {
        public int ShoppingListId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
        public bool IsFullfilled { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual ShoppingList ShoppingList { get; set; }
    }
}
