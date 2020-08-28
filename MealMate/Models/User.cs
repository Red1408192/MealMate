using System;
using System.Collections.Generic;

namespace MealMate.Models
{
    public partial class User
    {
        public User()
        {
            Ingredient = new HashSet<Ingredient>();
            Meal = new HashSet<Meal>();
            Pantry = new HashSet<Pantry>();
            Recipe = new HashSet<Recipe>();
            RecipeRating = new HashSet<RecipeRating>();
            ShoppingList = new HashSet<ShoppingList>();
            UserFamily = new HashSet<UserFamily>();
        }

        public int UserId { get; set; }
        public DateTime? CreationAtDate { get; set; }
        public string Username { get; set; }
        public int SettingLanguageId { get; set; }
        public bool SettingIsPublic { get; set; }
        public int? SettingDefaultLocation { get; set; }

        public virtual Locations SettingDefaultLocationNavigation { get; set; }
        public virtual Language SettingLanguage { get; set; }
        public virtual ICollection<Ingredient> Ingredient { get; set; }
        public virtual ICollection<Meal> Meal { get; set; }
        public virtual ICollection<Pantry> Pantry { get; set; }
        public virtual ICollection<Recipe> Recipe { get; set; }
        public virtual ICollection<RecipeRating> RecipeRating { get; set; }
        public virtual ICollection<ShoppingList> ShoppingList { get; set; }
        public virtual ICollection<UserFamily> UserFamily { get; set; }
    }
}
