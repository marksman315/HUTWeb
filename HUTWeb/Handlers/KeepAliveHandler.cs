using System;
using HUTWeb.Helpers;
using Newtonsoft.Json;

namespace HUTWeb.Handlers
{
    public class KeepAliveHandler : BaseHandler
    {        
        public KeepAliveHandler() : base()
        {
        }
      
        public string GetKeepAlive()
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "KeepAlive");

            var result = HttpHelper.GetValues(uri).Result;

            if (result != null)
            {
                return JsonConvert.DeserializeObject<string>(result);
            }

            return null;
        }
    }
}