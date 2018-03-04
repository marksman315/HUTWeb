using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HUTModels;
using HUTWeb.Handlers;
using HUTWeb.Models;

namespace HUTWeb.Controllers
{
    public class FoodController : Controller
    {
        public ActionResult Index()
        {
            return View("Foods");
        }

        //GET: Food
        public JsonResult GetListOfFoods(string searchTerm)
        {
            FoodHandler handler = new FoodHandler();
            List<Food> foods = handler.GetFilteredListOfFoods(searchTerm);            

            return Json(foods, JsonRequestBehavior.AllowGet);            
        }

        [HttpPost]
        public JsonResult Insert(string description, int caloriesPer100Grams)
        {           
            FoodHandler handler = new FoodHandler();
            handler.Insert(description, caloriesPer100Grams);

            // temporary
            return Json("Success");
        }        

        [HttpPut]
        public ActionResult Update(string description, int caloriesPer100Grams, int foodId)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }      
        
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
