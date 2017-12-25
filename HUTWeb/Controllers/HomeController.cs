using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HUTModels;
using HUTWeb.Models;

namespace HUTWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PersonHandler handler = new PersonHandler();
            HomeModel model = new HomeModel();

            List<Person> list = handler.GetAll();
            List<SelectListItem> items = new List<SelectListItem>();
            
            foreach (Person p in list)
            {
                items.Add(new SelectListItem() { Text = p.Firstname + " " + p.Lastname, Value = p.PersonId.ToString() });
            }

            model.Persons = items;

            return View(model);
        }

        [HttpPost]
        public JsonResult RecordWeight(string personId, string weightValue)
        {           
            WeightHandler handler = new WeightHandler();
            handler.Insert(Convert.ToInt32(personId), Convert.ToDecimal(weightValue), DateTime.Now);

            return Json("Posted Good");
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