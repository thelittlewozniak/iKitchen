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
            string[] ListIngredients = new string[nbi];
            string[] ListPrices = new string[nbi];
            if (nbi < 3) nbi = 3; //Can't have less than 3 ingredients
            ViewBag.NbIngredients = nbi;
            //Initializing lists with values to avoid ReferenceNullException
            for(int i=0;i<nbi;i++)
            {
                ListIngredients[i] = "";
                ListPrices[i] = "";
            }
            ViewBag.ListIngredients = ListIngredients;
            ViewBag.ListPrices = ListPrices;
            return View("RecipeForm");
        }
        [HttpPost]
        public ActionResult CheckRecipe(string name, List<string> ingredient, List<string> amount, List<string>price, string type)
        {
            //Checking
            List<string> error = new List<string>();
            bool ok = true;
            //Checking name of recipe
            if(name.Length<3)
            {
                ok = false;
                error.Add("The name of the recipe must contain at least 3 characters");
            }
            //Checking prices
            bool incorrectPrice = false;
            double inter;
            foreach (string p in price)
            {
                bool isDouble = double.TryParse(p, out inter);
                if (!isDouble || (Convert.ToDouble(p) < 0.10 || Convert.ToDouble(p) > 10 || p is null)) incorrectPrice = true;
            }
            if(incorrectPrice)
            {
                ok = false;
                error.Add("The price of the ingredients must be defined between 0.10 and 10 euros");
            }
            //Checking name of ingredients
            bool notEnoughChar = false;
            foreach(string i in ingredient)
            {
                if (i.Length < 3) notEnoughChar = true;
            }
            if (notEnoughChar)
            {
                ok = false;
                error.Add("The name of the ingredients must contain at least 3 characters");
            }
            //View redirection
            ViewBag.Name = name;
            ViewBag.ListIngredients = ingredient;
            ViewBag.ListAmounts = amount;
            ViewBag.ListPrices = price;
            ViewBag.NbIngredients = Convert.ToInt32(ingredient.Count);
            if (ok)
            {
                ViewBag.Type = type;
                return View();
            }
            else
            {
                ViewBag.ListErrors = error;
                return View("RecipeForm");
            }
        }
    }
}