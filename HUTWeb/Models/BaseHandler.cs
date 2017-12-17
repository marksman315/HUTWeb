using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HUTWeb.Models
{    
    public class BaseHandler
    {
        public string BaseWebAPIURL { get; set; }

        public BaseHandler()
        {
            this.BaseWebAPIURL = WebConfigurationManager.AppSettings["HUTWebAPIBaseURL"];
        }
    }
}