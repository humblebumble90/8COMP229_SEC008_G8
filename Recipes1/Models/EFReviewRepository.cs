using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;

        public EFReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Review> Reviews => context.Reviews;

        public void SaveReview(Review review)
        {
            if (review.ReviewId == 0)
            {
                context.Reviews.Add(review);
            }
            context.SaveChanges();
        }
    }
}
