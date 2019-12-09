using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public static class Repository
    {
        private static List<Recipe> recipes = new List<Recipe>();

        public static IEnumerable<Recipe> Recipe
        {
            get
            {
                return recipes;
            }
        }

        public static Recipe GetRecipe(int id)
        {
            return recipes.Find(r => r.RecipeId == id);
        }


        public static void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }
    }
}
