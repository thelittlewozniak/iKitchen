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
            int nbi = Convert.ToInt32(NbIngredients);
            if (nbi < 3) nbi = 3; //Can't have less than 3 ingredients
            ViewBag.NbIngredients = nbi;
            return View("RecipeForm");
        }
        [HttpPost]
        public ActionResult CheckRecipe(string name, string[] tabIngredients, string[] tabAmounts, string[]tabPrices)
        {
            ViewBag.Name = name;
            ViewBag.ListIngredients = tabIngredients;
            ViewBag.ListAmounts = tabAmounts;
            ViewBag.ListPrices = tabPrices;
            ViewBag.NbIngredients = tabIngredients.Length;
            return View();
        }
    }
}