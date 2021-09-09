using ContosoRecipes.Models;
using ContosoRecipes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoRecipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipesController(RecipeService service)
        {
            _recipeService = service;
        }

        [HttpGet]
        public ActionResult GetRecipes([FromQuery]int count)
        {
            var recipes = _recipeService.Get();

            if (!recipes.Any())
            {
                return NotFound();
            }

            return Ok(recipes.Take(count));
        } 
        
        [HttpGet("{id}")]
        public ActionResult GetRecipe(string id)
        {
            var recipe = _recipeService.Get(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRecipes(string id, [FromBody] Recipe recipe)
        {
            _recipeService.Update(id, recipe);
            
            return NoContent();
        }

        [HttpPost]
        public ActionResult CreateRecipes([FromBody] Recipe newRecipe)
        {
            var recipe = _recipeService.Create(newRecipe);
            if (recipe == null)
            {
                return BadRequest();
            }
            return Created("", newRecipe);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRecipes(string id)
        {
            _recipeService.Remove(id);

            return NoContent();
        }
    }
}
