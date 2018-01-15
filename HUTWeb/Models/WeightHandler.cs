using System;
using System.Collections.Generic;
using System.Linq;
using HUTModels;
using HUTWeb.Helpers;
using Newtonsoft.Json;

namespace HUTWeb.Models
{
    public class WeightHandler : BaseHandler
    {
        public WeightHandler() : base()
        {
        }

        public void Insert(int personId, decimal weightAmount, DateTime dateEntered)
        {            
            Weight weightModel = new Weight() { PersonId = personId, WeightAmount = weightAmount, DateEntered = dateEntered };

            Insert(weightModel);
        }

        public void Insert(Weight weightModel)
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "Weight");

            // the result is always going to be null for now
            var result = HttpHelper.PostValues(uri, weightModel).Result;
        }

        public List<Weight> GetWeights(int personId, DateTime startDate, DateTime endDate)
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "Weight?personId=" + personId + "&startDate=" + startDate.ToString("MM-dd-yyyy") + "&endDate=" + endDate.ToString("MM-dd-yyyy"));

            var result = HttpHelper.GetValues(uri).Result;

            if (result != null)
            {
                List<Weight> weights = JsonConvert.DeserializeObject<List<Weight>>(result);
                return weights;
            }

            return null;
        }

        public List<WeightAndDateModel> GetWeightsAndDates(int personId, DateTime startDate, DateTime endDate)
        {
            List<Weight> weights = GetWeights(personId, startDate, endDate);

            if (weights != null)
            {
                List<WeightAndDateModel> list = weights.Select(item => new WeightAndDateModel()
                                                                        {
                                                                            Date = item.DateEntered.ToString("MM/dd/yyyy"),
                                                                            Weight = item.WeightAmount.ToString()
                                                                        }).ToList<WeightAndDateModel>();

                return list;
            }

            return null;
        }

        public List<XYModel> GetWeightsAndDatesAsXAndY(int personId, DateTime startDate, DateTime endDate)
        {
            List<Weight> weights = GetWeights(personId, startDate, endDate);

            if (weights != null)
            {
                List<XYModel> list = weights.Select(item => new XYModel()
                                                                {
                                                                    x = item.DateEntered.ToString("MM/dd/yyyy"),
                                                                    y = item.WeightAmount.ToString()
                                                                }).ToList<XYModel>();

                return list;
            }

            return null;
        }
    }
}