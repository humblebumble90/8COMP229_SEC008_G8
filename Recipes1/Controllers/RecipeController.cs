using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class RecipeController : Controller
    {
        private IRecipeRepository repository;
 
        public RecipeController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public ViewResult List() => View(repository.Recipes);

        public ViewResult ViewRecipe(int id) =>
            View(repository.Recipes
                    .FirstOrDefault(r => r.RecipeId == id));


        [Authorize]
        public ViewResult Edit(int recipeId) =>
            View(repository.Recipes
                    .FirstOrDefault(r => r.RecipeId == recipeId));

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            repository.SaveRecipe(recipe);
            return RedirectToAction("List");
        }

        [Authorize]
        public ViewResult AddRecipe() => View("Edit", new Recipe());

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeId);
            return RedirectToAction("List");
        }
    }
}