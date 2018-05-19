using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onessaye.Views.ViewClasses;
using onessaye.Models.POCO;
using onessaye.Models.DAL;

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
        public ActionResult DisplayRecipeForm(string Cook, int nbrDate=1, string NbIngredients="3")
        {
            int nbi = Convert.ToInt32(NbIngredients);
            int nbd = nbrDate;
            if (nbi < 3) nbi = 3; //Can't have less than 3 ingredients neither more than 20
            if (nbi > 20) nbi = 20; //Can't have more than 20 ingredients
            ViewBag.NbIngredients = nbi;
            //Initializing lists with values to avoid ReferenceNullException
            string[] ListIngredients = new string[nbi];
            string[] ListPrices = new string[nbi];
            string[] ListAmounts = new string[nbi];
            for (int i = 0; i < nbi; i++)
            {
                ListIngredients[i] = " ";
                ListPrices[i] = " ";
            }
            //Nathan Pire
                List<string>ListDateSite = new List<string>();
                List<string> ListDateQ = new List<string>();
                ListDateSite.Add("");
            for(int j=0;j<nbd;j++)
            { 
                ListDateSite.Add("");
                ListDateQ.Add("");
            }
            ViewBag.ListIngredients = ListIngredients;
            ViewBag.ListPrices = ListPrices;
            ViewBag.ListAmounts = ListAmounts;
            ViewBag.Cook = Cook;
            ViewBag.ListDate = ListDateSite;
            ViewBag.ListQ = ListDateQ;
            ViewBag.nbd = nbd;
            return View("RecipeForm");
        }
        [HttpPost]
        public ActionResult CheckRecipe(string name, List<string> ingredient, List<string> amount, List<string> unit,List<string>price, string type, string cook_nickname, List<string> date,List<string>quantity)
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
                for(int j=0;j<i.Length;j++)
                {
                    if (i[j] >= '0' && i[j] <= '9') wrongChar = true;
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
                    if (!isDouble || inter < 10 || inter > 1000 || amount[i] is null) incorrectAmountDouble = true;
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
                error.Add("The amount of the ingredients quantified in ml or g must be defined between 10 and 1000");
            }
            ViewBag.Cook = cook_nickname;
            //View redirection
            if (ok)
            {
                UserDAL dalU = new UserDAL();
                RecipeDAL dalR = new RecipeDAL();
                Recipe recipe = new Recipe(name, type);
                for (int i=0;i<ingredient.Count;i++)
                {
                    switch(unit[i])
                    {
                        case "g":
                            {
                                SolidIngredient ing = new SolidIngredient(ingredient[i], Convert.ToDouble(amount[i]), Convert.ToDouble(price[i]));
                                recipe.AddIngredient(ing);
                                break;
                            }
                        case "ml":
                            {
                                LiquidIngredient ing = new LiquidIngredient(ingredient[i], Convert.ToDouble(amount[i]), Convert.ToDouble(price[i]));
                                recipe.AddIngredient(ing);
                                break;
                            }
                        case "teaspoon":
                            {
                                TeaspoonIngredient ing = new TeaspoonIngredient(ingredient[i], Convert.ToDouble(amount[i]), Convert.ToDouble(price[i]));
                                recipe.AddIngredient(ing);
                                break;
                            }
                        case "unit":
                            {
                                UnitIngredient ing = new UnitIngredient(ingredient[i], Convert.ToDouble(amount[i]), Convert.ToDouble(price[i]));
                                recipe.AddIngredient(ing);
                                break;
                            }
                    }
                }
                for(int i=0;i<date.Count;i++)
                {
                    Date dat = new Date(Convert.ToDateTime(date[i]), Convert.ToInt32(quantity[i]));
                    recipe.AvailableDate.AddDate(dat);
                }
                recipe.CostPrice = recipe.CalculCostPrice();
                recipe.SellingPrice = recipe.CalculSellingPrice();
                dalU.AddRecipe(cook_nickname, recipe);
                DisplayRecipeInformation d = new DisplayRecipeInformation(recipe);
                return View("ConfirmedRecipe",d);
            }
            else
            {
                ViewBag.Name = name;
                ViewBag.ListIngredients = ingredient;
                ViewBag.ListAmounts = amount;
                ViewBag.ListPrices = price;
                ViewBag.ListUnits = unit;
                ViewBag.NbIngredients = Convert.ToInt32(ingredient.Count);
                ViewBag.ListErrors = error;
                return View("RecipeForm");
            }
        }
        public ActionResult BackToProfilePage(string cook_nickname)
        {
            UserDAL dal = new UserDAL();
            Cook user = dal.GetCook(cook_nickname);
            return RedirectToAction("ProfilePageCook", "User", user);
        }
        public ActionResult Catalogue()
        {
            RecipeDAL dal = new RecipeDAL();
            ViewBag.Catalogue = dal.GetRecipes();
            return View();
        }
        public ActionResult CheckRecipe(int id_recipe)
        {
            RecipeDAL dal = new RecipeDAL();
            Recipe r = dal.GetRecipe(id_recipe);
            DisplayRecipeInformation d = new DisplayRecipeInformation(r);
            return View(d);
        }
        public ActionResult DeleteRecipe()
        {
            return View();
        }
    }
}