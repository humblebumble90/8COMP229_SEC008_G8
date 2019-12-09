using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        Name = "Tomato Soup",
                        Description = "A tasty tomato soup",
                        Ingredients = "Tomatoes, Water, Salt"
                    },

                    new Recipe
                    {
                        Name = "Apple Pie",
                        Description = "A home made apple pie",
                        Ingredients = "Apples, Flour, Dough"
                    },

                    new Recipe
                    {
                        Name = "Carrot Cake",
                        Description = "A delicious carrot cake",
                        Ingredients = "Carrots, Flour, Butter"
                    }
                    );

                context.SaveChanges();
            }

            if(!context.Reviews.Any())
            {
                context.Reviews.AddRange(
                    new Review
                    {
                        Name = "Joe",
                        Comments = "Ok",
                        Rating = "3 Stars",
                        RecipeId = 1
                    },

                    new Review
                    {
                        Name="Bob",
                        Comments = "Good",
                        Rating = "5 Stars",
                        RecipeId = 2
                    },

                    new Review
                    {
                        Name = "User1",
                        Comments = "Good",
                        Rating = "4 Stars",
                        RecipeId = 3
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
