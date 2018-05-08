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
            if (nbi < 3) nbi = 3; //Can't have less than 3 ingredients neither more than 20
            if (nbi > 20) nbi = 20; //Can't have more than 20 ingredients
            ViewBag.NbIngredients = nbi;
            //Initializing lists with values to avoid ReferenceNullException
            string[] ListIngredients = new string[nbi];
            string[] ListPrices = new string[nbi];
            string[] ListAmounts = new string[nbi];
            for (int i = 0; i < nbi; i++)
            {
                ListIngredients[i] = "";
                ListPrices[i] = "";
            }
            ViewBag.ListIngredients = ListIngredients;
            ViewBag.ListPrices = ListPrices;
            ViewBag.ListAmounts = ListAmounts;
            return View("RecipeForm");
        }
        [HttpPost]
        public ActionResult CheckRecipe(string name, List<string> ingredient, List<string> amount, List<string> unit,List<string>price, string type)
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
            foreach (string p in price)
            {
                bool isDouble = double.TryParse(p, out double inter);
                if (!isDouble || inter < 0.10 || inter > 10 || p is null) incorrectPrice = true;
            }
            if(incorrectPrice)
            {
                ok = false;
                error.Add("The price of the ingredients must be defined between 0.10 and 10 euros");
            }
            //Checking name of ingredients
            bool notEnoughChar = false, wrongChar = false;
            foreach(string i in ingredient)
            {
                if (i.Length < 3) notEnoughChar = true;
                else
                {
                    for(int j=0;j<i.Length;j++)
                    {
                        if (i[j] >= '0' && i[j] <= '9') wrongChar = true;
                    }
                }
            }
            if (notEnoughChar)
            {
                ok = false;
                error.Add("The name of the ingredients must contain at least 3 characters");
            }
            if(wrongChar)
            {
                ok = false;
                error.Add("The name of the ingredients can't contain digits");
            }
            //Checking amount of ingredients
            bool incorrectAmountInt = false, incorrectAmountDouble = false;
            for(int i=0;i<amount.Count;i++)
            {
                if(unit[i]=="unit"||unit[i]=="teaspoon")
                {
                    bool isInt = int.TryParse(amount[i], out int inter);
                    if (!isInt || inter < 1 || inter > 10 || amount[i] is null) incorrectAmountInt = true;
                }
                else
                {
                    bool isDouble = double.TryParse(amount[i], out double inter);
                    if (!isDouble || inter < 10 || inter > 500 || amount[i] is null) incorrectAmountDouble = true;
                }
            }
            if(incorrectAmountInt)
            {
                ok = false;
                error.Add("The amount of the ingredients quantified in teaspoon or unit must be defined between 1 and 10");
            }
            if(incorrectAmountDouble)
            {
                ok = false;
                error.Add("The amount of the ingredients quantified in ml or g must be defined between 10 and 500");
            }
            //View redirection
            ViewBag.Name = name;
            ViewBag.ListIngredients = ingredient;
            ViewBag.ListAmounts = amount;
            ViewBag.ListPrices = price;
            ViewBag.ListUnits = unit;
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
        public ActionResult AcceptedRecipe()
        {
            return View();
        }
    }
}