using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class ShoppingList
    {
        public int ShoppingListId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAtDate { get; set; }
        public DateTime? CompletedAtDate { get; set; }

        public virtual User User { get; set; }
    }
}
