using ContosoRecipes.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoRecipes.Services
{
    public class RecipeService
    {
        private readonly IMongoCollection<Recipe> _recipes;

        public RecipeService(IRecipeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _recipes = database.GetCollection<Recipe>(settings.RecipesCollectionName);
        }

        public List<Recipe> Get() => _recipes.Find<Recipe>(recipe => true).ToList();

        public Recipe Get(string id) => _recipes.Find<Recipe>(recipe => recipe.Id == id).FirstOrDefault();

        public Recipe Create(Recipe recipe)
        {
            recipe.Id = Guid.NewGuid().ToString();
            _recipes.InsertOne(recipe);
            return recipe;
        }

        public void Update(string id, Recipe recipeIn) => _recipes.ReplaceOne(recipe => recipe.Id == id, recipeIn);

        public void Remove(Recipe recipeIn) => _recipes.DeleteOne(recipe => recipe.Id == recipeIn.Id);
        public void Remove(string id) => _recipes.DeleteOne(recipe => recipe.Id == id);
    }
}
