using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using HUTModels;
using HUTWeb.Helpers;
using Newtonsoft.Json;

namespace HUTWeb.Handlers
{
    public class FoodHandler : BaseHandler
    {
        public static ObjectCache foodCache = MemoryCache.Default;
        public static bool mustRefreshCache = false;

        public FoodHandler() : base()
        {            
        }

        public void Insert(string description, int caloriesPer100Grams)
        {
            Food foodModel = new Food() { CaloriesPer100Grams = caloriesPer100Grams, Description = description };

            Insert(foodModel);
        }

        public void Insert(Food foodModel)
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "Food");

            // the result is always going to be null for now
            var result = HttpHelper.PostValues(uri, foodModel).Result;

            // set the cache to be reset. Think about doing this piecemeal and add to cache instead or reset the whole thing
            mustRefreshCache = true;
        }

        public void Update(string description, int caloriesPer100Grams, int foodId)
        {
            Food foodModel = new Food() { CaloriesPer100Grams = caloriesPer100Grams, Description = description, FoodId = foodId };

            Update(foodModel);
        }

        public void Update(Food foodModel)
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "Food");

            // the result is always going to be null for now
            var result = HttpHelper.PutValues(uri, foodModel).Result;

            // set the cache to be reset. Think about doing this piecemeal and add to cache instead or reset the whole thing
            mustRefreshCache = true;
        }

        public List<Food> GetListOfFoods()
        {
            List<Food> foods = new List<Food>();

            if (mustRefreshCache || foodCache["foods"] == null)
            {
                Uri uri = new Uri(this.BaseWebAPIURL + "Food/GetListOfFoods");

                var result = HttpHelper.GetValues(uri).Result;

                if (result != null)
                {
                    foods = JsonConvert.DeserializeObject<List<Food>>(result);
                    foodCache.Set("foods", foods, DateTimeOffset.Now.AddHours(4));                    
                }
            }
            else
            {
                foods = foodCache["foods"] as List<Food>;                
            }

            return foods;
        }

        public List<Food> GetFilteredListOfFoods(string searchTerm)
        {
            List<Food> foods = GetListOfFoods();

            if (String.IsNullOrWhiteSpace(searchTerm))
            {
                return foods;
            }
            else
            {
                return foods.Where(x => x.Description.ToLower().Contains(searchTerm.ToLower())).ToList<Food>();
            }
        }
    }
}