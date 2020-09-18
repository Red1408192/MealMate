using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class UserFamilyDietIngr
    {
        public int FamilyMemberId { get; set; }
        public int IngredientId { get; set; }

        public virtual UserFamily FamilyMember { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
