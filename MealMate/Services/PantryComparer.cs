using System;
using System.Collections.Generic;
using System.Linq;
using MealMate.Data;
using MealMate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MealMate.Services
{
    public class PantryComparer
    {
        List<KeyValuePair<Ingredient, double>> pantryLimits = new List<KeyValuePair<Ingredient, double>>();

        public PantryComparer(List<KeyValuePair<Ingredient, double>> _pantryLimits)
        {
            pantryLimits = _pantryLimits;
        }
        public bool Compare(IQueryable<KeyValuePair<Ingredient, double>> recipeIngredients)
        {
            foreach(KeyValuePair<Ingredient, double> set in recipeIngredients)
            {
                if(pantryLimits.Where(a => a.Key == set.Key).FirstOrDefault().Value - set.Value <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
