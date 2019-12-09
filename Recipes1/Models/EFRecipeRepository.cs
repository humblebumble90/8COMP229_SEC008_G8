using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;

        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.RecipeId == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe recipeEntry = context.Recipes
                    .FirstOrDefault(p => p.RecipeId == recipe.RecipeId);

                if (recipeEntry != null)
                {
                    recipeEntry.Name = recipe.Name;
                    recipeEntry.Description = recipe.Description;
                    recipeEntry.Ingredients = recipe.Ingredients;
                }
            }
            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int RecipeId)
        {
            Recipe recipeEntry = context.Recipes
                .FirstOrDefault(p => p.RecipeId == RecipeId);

            if (recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }

            return recipeEntry;
        }
    }
}

