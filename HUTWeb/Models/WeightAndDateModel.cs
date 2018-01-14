using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace HUTWeb.Models
{
    public class WeightAndDateModel
    {
        [JsonProperty("weight")]
        public string Weight { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}