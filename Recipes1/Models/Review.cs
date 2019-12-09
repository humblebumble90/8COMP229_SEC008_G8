using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Comments { get; set; }

        [Required]
        public string Rating { get; set; }

        public int RecipeId { get; set; }
    }
}
