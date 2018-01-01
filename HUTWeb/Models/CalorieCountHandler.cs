using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HUTModels;
using HUTWeb.Helpers;
using Newtonsoft.Json;

namespace HUTWeb.Models
{
    public class CalorieCountHandler : BaseHandler
    {
        public CalorieCountHandler() : base()
        {
        }

        public List<CalorieCount> Insert(int personId, int calories, DateTime datetimeEntered)
        {
            CalorieCount calorieModel = new CalorieCount() { PersonId = personId, Calories = calories, DatetimeEntered = datetimeEntered };

            var counts = Insert(calorieModel);
            return counts;
        }

        public List<CalorieCount> Insert(CalorieCount calorieModel)
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "CalorieCount");

            // the result is always going to be null for now
            var result = HttpHelper.PostValues(uri, calorieModel).Result;

            if (result != null)
            {
                List<CalorieCount> counts = JsonConvert.DeserializeObject<List<CalorieCount>>(result);
                return counts;
            }

            return null;
        }
    }    
}