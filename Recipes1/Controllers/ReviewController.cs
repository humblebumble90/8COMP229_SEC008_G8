using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewRepository repository;

        public ReviewController(IReviewRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int RecipeId) => View(
            repository.Reviews.Where(r => r.RecipeId == RecipeId).ToList());

        public ViewResult Review(int RecipeId) => View("Review", new Review());

        [HttpPost]
        public IActionResult Review(Review review, int RecipeId)
        {
            review.RecipeId = RecipeId;
            repository.SaveReview(review);
            return Redirect("List?recipeid= " + RecipeId);
        }
    }
}