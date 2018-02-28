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
            //FoodHandler handler = new FoodHandler();
            //List<Food> foods = handler.GetListOfFoods();

            //FoodListModel model = new FoodListModel();

            //foreach (var food in foods)
            //{
            //    model.FoodNames.Add(food.Description);
            //}

            return View("Foods");
        }

        //GET: Food
        public JsonResult GetListOfFoods(string searchTerm)
        {
            FoodHandler handler = new FoodHandler();
            List<Food> foods = handler.GetFilteredListOfFoods(searchTerm);            

            return Json(foods, JsonRequestBehavior.AllowGet);            
        }

        // POST: Food/Create
        [HttpPost]
        public ActionResult InsertFood(string description, int caloriesPer100Grams)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }        

        [HttpPut]
        public ActionResult Edit(int id, FormCollection collection)
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
        public ActionResult Delete(int id, FormCollection collection)
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
