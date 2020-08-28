using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class Note
    {
        public int NoteId { get; set; }
        public Guid NotNameId { get; set; }
        public Guid NotDescriptionId { get; set; }
    }
}
