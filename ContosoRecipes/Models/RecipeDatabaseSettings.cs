﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoRecipes.Models
{
    public class RecipeDatabaseSettings : IRecipeDatabaseSettings
    {
        public string RecipesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IRecipeDatabaseSettings
    {
        string RecipesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
