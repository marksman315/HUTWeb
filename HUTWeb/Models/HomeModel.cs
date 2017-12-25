using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HUTModels;

namespace HUTWeb.Models
{
    public class HomeModel
    {
        public List<SelectListItem> Persons { get; set; }
    }
}