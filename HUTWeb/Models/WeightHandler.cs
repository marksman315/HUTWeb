using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HUTModels;
using HUTWeb.Helpers;

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
    }
}