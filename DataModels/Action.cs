using System;
using System.Collections.Generic;

namespace DataModels
{
    public partial class Action
    {
        public Action()
        {
            RecipeStep = new HashSet<RecipeStep>();
        }

        public int ActionId { get; set; }
        public Guid ActNameId { get; set; }
        public Guid ActDescriptionShortId { get; set; }
        public Guid ActDescriptionLongId { get; set; }

        public virtual ICollection<RecipeStep> RecipeStep { get; set; }
    }
}
