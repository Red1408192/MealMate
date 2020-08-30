using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealMate.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Pantry = new HashSet<Pantry>();
            UserFamily = new HashSet<UserFamily>();
        }
        public DateTime CreationAtDate { get; set; }
        public virtual ICollection<Pantry> Pantry { get; set; }
        public virtual ICollection<UserFamily> UserFamily { get; set; }
    }
}
