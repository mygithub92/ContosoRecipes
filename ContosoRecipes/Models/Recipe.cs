using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoRecipes.Models
{
    public class Recipe
    {
        [JsonProperty]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Directions { get; set; }
        [Required]
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public DateTime Updated { get; set; }
    }

    public class Ingredient
    {
        [Required]
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Unit { get; set; }
    }
}
