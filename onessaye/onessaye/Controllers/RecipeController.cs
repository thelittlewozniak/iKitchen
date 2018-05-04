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
        public ActionResult CheckRecipe(string name, List<string> ingredient, List<string> amount, List<string>price, string type)
        {
            //Checking
            List<string> error = new List<string>();
            bool ok = true;
            bool alreadyWrongPrice = false;
            double inter;
            foreach (string p in price)
            {
                if (!alreadyWrongPrice)
                {
                    bool isDouble = double.TryParse(p, out inter);
                    if (!isDouble || (Convert.ToDouble(p) < 0.10 || Convert.ToDouble(p) > 10 || p is null))
                    {
                        ok = false;
                        error.Add("The price of the ingredients must be defined between 0.10 and 10 euros");
                        alreadyWrongPrice = true;
                    }
                }
            }
            //View redirection
            if (ok)
            {
                ViewBag.Name = name;
                ViewBag.ListIngredients = ingredient;
                ViewBag.ListAmounts = amount;
                ViewBag.ListPrices = price;
                ViewBag.NbIngredients = ingredient.Count;
                ViewBag.Type = type;
                return View();
            }
            else
            {
                ViewBag.ListErrors = error;
                ViewBag.NbIngredients = 3;
                return View("RecipeForm");
            }
        }
    }
}