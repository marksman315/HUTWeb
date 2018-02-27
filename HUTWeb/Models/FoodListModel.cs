using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HUTWeb.Models
{
    public class FoodListModel
    {
        public FoodListModel()
        {
            FoodNames = new List<string>();
        }

        public List<string> FoodNames { get; set; }
    }
}