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
    public class RecipeController : Controller
    {
        public ActionResult Index()
        {
            RecipeHandler handler = new RecipeHandler();
            RecipeModel model = new RecipeModel();

            List<Recipe> list = handler.GetListOfActiveRecipes();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (Recipe p in list)
            {
                items.Add(new SelectListItem() { Text = p.Description + " " + p.DateEntered.ToString("MM/dd/yyyy"), Value = p.RecipeId.ToString() });
            }

            model.ActiveRecipes = items;

            return View("Recipes", model);
        }        
       
        [HttpGet]
        public ActionResult GetRecipeWithIngredients(int recipeId)
        {

            return View();
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Recipe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recipe/Edit/5
        [HttpPost]
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

        // GET: Recipe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recipe/Delete/5
        [HttpPost]
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
