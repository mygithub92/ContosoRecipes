using ContosoRecipes.Models;
using ContosoRecipes.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoRecipes
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RecipeDatabaseSettings>(configuration.GetSection(nameof(RecipeDatabaseSettings)));
            services.AddSingleton<IRecipeDatabaseSettings>(provider => provider.GetRequiredService<IOptions<RecipeDatabaseSettings>>().Value);
            services.AddSingleton<RecipeService>();

            return services;
        }
    }
}
