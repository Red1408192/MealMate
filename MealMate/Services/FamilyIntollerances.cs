using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealMate.Data;
using MealMate.Models;

namespace MealMate.Services
{
    public class FamilyIntollerances
    {
        public string userId { get; set; }
        MealMateNewContext context { get; set; }


        public FamilyIntollerances(string user)
        {
            this.userId = user;
        }

        public FamilyIntollerances(MealMateNewContext _context)
        {
            context = _context;
        }

        public List<Ingredient> GenerateIngredients(IEnumerable<int> familyMembers)
        {
            IEnumerable<UserFamily> family = context
                    .UserFamily.Where(a => a.UserId == userId)
                    .Where(a => familyMembers
                    .Contains(a.FamilyMember));

            IEnumerable<Ingredient> ingredientList = context.Ingredient
                .Where(b => context
                .UserFamilyDietIngr
                .Where(a => family
                .Contains(a.FamilyMember))
                .Select(c => c.IngredientId)
                .Contains(b.IngredientId));

            IEnumerable<Desease> deseases = context.Desease
                .Where(b => context
                .UserFamilyDesease
                .Where(a => family
                .Contains(a.UserFamilyMember))
                .Select(c => c.DeseaseId)
                .Contains(b.DeseaseId));

            IEnumerable<Diet> diet = context.Diet
                .Where(b => context
                .UserFamilyDiet
                .Where(a => family
                .Contains(a.UserFamilyMember))
                .Select(c => c.DietId)
                .Contains(b.DietId));
            IEnumerable<Ingredient> ingredientList2 = context.DeseaseIngredientBlacklist.Where(b => deseases.ToList().Contains(b.Desease)).Select(c => c.Ingredient);
            IEnumerable<Ingredient> ingredientList3 = context.DietIngredientBlacklist.Where(b => diet.ToList().Contains(b.Diet)).Select(c => c.Ingredient);

            List<Ingredient> ingredientsBL = ingredientList.Union(ingredientList2).Union(ingredientList3).ToList();

            return ingredientsBL;
        }

        public List<Flag> GenerateFlags(IEnumerable<int> familyMembers)
        {
            IEnumerable<UserFamily> family = context
                .UserFamily.Where(a => a.UserId == userId)
                .Where(a => familyMembers
                .Contains(a.FamilyMember));

            IEnumerable<Flag> flagList = context.Flag
                .Where(b => context
                .UserFamilyDietFlag
                .Where(a => family
                .Contains(a.FamilyMember))
                .Select(c => c.FlagId)
                .Contains(b.FlagId));

            IEnumerable<Desease> deseases = context.Desease
                .Where(b => context
                .UserFamilyDesease
                .Where(a => family
                .Contains(a.UserFamilyMember))
                .Select(c => c.DeseaseId)
                .Contains(b.DeseaseId));

            IEnumerable<Diet> diet = context.Diet
                .Where(b => context
                .UserFamilyDiet
                .Where(a => family
                .Contains(a.UserFamilyMember))
                .Select(c => c.DietId)
                .Contains(b.DietId));

            IEnumerable<Flag> flagList2 = context.DeseaseFlagBlacklist.Where(b => deseases.ToList().Contains(b.Desease)).Select(c => c.Flag);
            IEnumerable<Flag> flagList3 = context.DietFlagBlacklist.Where(b => diet.ToList().Contains(b.Diet)).Select(c => c.Flag);

            List<Flag> FlagBL = flagList.Union(flagList2).Union(flagList3).ToList();

            return FlagBL;
        }
    }
}
