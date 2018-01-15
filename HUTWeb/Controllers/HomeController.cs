using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HUTModels;
using HUTWeb.Models;
using Newtonsoft.Json;

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
        public JsonResult RecordWeight(string personId, string weightValue, string currentDateTime)
        {
            DateTime localTime = DateTime.Parse(currentDateTime);
            WeightHandler handler = new WeightHandler();
            handler.Insert(Convert.ToInt32(personId), Convert.ToDecimal(weightValue), localTime);

            return Json("Posted Good");
        }

        [HttpPost]
        public JsonResult RecordCalories(string personId, string calorieValue, string currentDateTime)
        {
            DateTime localTime = DateTime.Parse(currentDateTime);
            CalorieCountHandler handler = new CalorieCountHandler();
            List<CalorieCount> counts = handler.Insert(Convert.ToInt32(personId), Convert.ToInt32(calorieValue), localTime);

            int total = counts.Select(x => x.Calories).Sum();

            return Json("Total Calories " + total);
        }

        public JsonResult GetWeightForLastThrityDays(string personId, string currentDateTime)
        {
            DateTime endDate = DateTime.Parse(currentDateTime);
            DateTime startDate = endDate.AddDays(-30);
            WeightHandler handler = new WeightHandler();

            //List<WeightAndDateModel> weightAndDateModel = handler.GetWeightsAndDates(Convert.ToInt32(personId), startDate, endDate);

            List<XYModel> weightAndDateModel = handler.GetWeightsAndDatesAsXAndY(Convert.ToInt32(personId), startDate, endDate);

            return Json(weightAndDateModel);
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