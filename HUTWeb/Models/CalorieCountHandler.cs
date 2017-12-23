using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HUTModels;
using HUTWeb.Helpers;

namespace HUTWeb.Models
{
    public class CalorieCountHandler : BaseHandler
    {
        public CalorieCountHandler() : base()
        {
        }

        public void Insert(int personId, int calories, DateTime datetimeEntered)
        {
            CalorieCount calorieModel = new CalorieCount() { PersonId = personId, Calories = calories, DatetimeEntered = datetimeEntered };

            Insert(calorieModel);
        }

        public void Insert(CalorieCount calorieModel)
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "Weight");

            // the result is always going to be null for now
            var result = HttpHelper.PostValues(uri, calorieModel).Result;
        }
    }    
}