using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HUTModels;
using HUTWeb.Helpers;
using Newtonsoft.Json;

namespace HUTWeb.Models
{
    public class PersonHandler : BaseHandler
    {
        public PersonHandler() : base()
        {
        }

        public List<Person> GetAll()
        {
            Uri uri = new Uri(this.BaseWebAPIURL + "Person/GetAll");
            string content = HttpHelper.GetValues(uri).Result;

            List<Person> persons = JsonConvert.DeserializeObject<List<Person>>(content);

            return persons;
        }
    }
}