using System;
using System.Collections.Generic;
using HUTModels;
using HUTWeb.Helpers;
using Newtonsoft.Json;

namespace HUTWeb.Handlers
{
    public class RecipeHandler : BaseHandler
    {
        public RecipeHandler() : base()
        {
        }
    
        public List<Recipe> GetListOfActiveRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();

            Uri uri = new Uri(this.BaseWebAPIURL + "Recipe/GetListOfActiveRecipes");

            var result = HttpHelper.GetValues(uri).Result;

            if (result != null)
            {
                recipes = JsonConvert.DeserializeObject<List<Recipe>>(result);
            }

            return recipes;
        }

        public Recipe GetRecipeWithIngredients(int recipeId)
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "Recipe/GetRecipeWithIngredients?recipeid=" + recipeId);

            var result = HttpHelper.GetValues(uri).Result;

            if (result != null)
            {
                return JsonConvert.DeserializeObject<Recipe>(result);
            }

            return null;
        }
    }
}