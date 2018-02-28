using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HUTModels;
using HUTWeb.Helpers;
using HUTWeb.Models;
using Newtonsoft.Json;

namespace HUTWeb.Handlers
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

        public bool InsertCalorieCountOffDay(int personId, DateTime datetimeEntered)
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "CalorieCountOffDay");
            CalorieCountOffDay offDayModel = new CalorieCountOffDay() { PersonId = personId, DateEntered = datetimeEntered.Date };

            var result = HttpHelper.PostValues(uri, offDayModel);

            // always true for now
            return true;
        }

        public List<CalorieCount> GetTotalsPerDayInDateRange(int personId, DateTime startDate, DateTime endDate)
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "CalorieCount/GetTotalsPerDayInDateRange?personId=" + personId + "&startDate=" + startDate.ToString("MM-dd-yyyy") + "&endDate=" + endDate.ToString("MM-dd-yyyy"));

            var result = HttpHelper.GetValues(uri).Result;

            if (result != null)
            {
                List<CalorieCount> calorieCounts = JsonConvert.DeserializeObject<List<CalorieCount>>(result);
                return calorieCounts;
            }

            return null;
        }

        public List<XYModel> GetCaloriesAndDatesAsXAndY(int personId, DateTime startDate, DateTime endDate)
        {
            List<CalorieCount> counts = GetTotalsPerDayInDateRange(personId, startDate, endDate);

            if (counts != null)
            {
                List<XYModel> list = counts.Select(item => new XYModel()
                                                    {
                                                        x = item.DatetimeEntered.ToString("MM/dd/yyyy"),
                                                        y = item.Calories.ToString()
                                                    }).ToList<XYModel>();

                return list;
            }

            return null;
        }
    }    
}