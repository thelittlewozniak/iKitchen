using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Bisconti Flavian

namespace onessaye.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayRecipeForm(string NbIngredients="3")
        {
            ViewBag.NbIngredients = int.Parse(NbIngredients);
            return View("RecipeForm");
        }
        [HttpGet]
        public ActionResult CheckRecipe()
        {
            return View();
        }
    }
}