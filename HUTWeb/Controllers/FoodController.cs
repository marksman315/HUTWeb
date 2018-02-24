using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HUTModels;
using HUTWeb.Handlers;

namespace HUTWeb.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult GetListOfFoods()
        {
            FoodHandler handler = new FoodHandler();
            List<Food> foods = handler.GetListOfFoods();

            return View();
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
