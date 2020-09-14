using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealMate.Data;
using MealMate.Models;

namespace MealMate.Services
{
    public class PantryIngredients
    {
        public string userId { get; set; }
        MealMateNewContext context { get; set; }

        public PantryIngredients(string user)
        {
            this.userId = user;
        }

        public PantryIngredients(MealMateNewContext _context)
        {
            context = _context;
        }

        public List<KeyValuePair<Ingredient, double>> GenerateIngredients()
        {
            IEnumerable<PantryOvercard> overcards = context.PantryOvercard.Where(a => a.PantryId == context
                                                                          .Pantry.Where(b => b.UserId == userId)
                                                                          .FirstOrDefault().PantryId);
            IEnumerable<KeyValuePair<Ingredient, double>> ingredients = context.PantryIngredient
                                                          .Where(a => overcards
                                                          .Contains(a.PantryOc))
                                                          .Select(b => new KeyValuePair<Ingredient,double>(b.Ingredient, b.Quantity));
            return ingredients.ToList();
        }
    }
}
