using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HUTWeb.Models;

namespace HUTWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PersonHandler handler = new PersonHandler();
           
            return View(handler.GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}