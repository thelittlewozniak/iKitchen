using onessaye.Models.DAL;
using onessaye.Models.POCO;
using onessaye.Views.ViewClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onessaye.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Order(string recipe_id)
        {
            ViewBag.RecipeiD = recipe_id;
            return View("LoginOrder");
        }
        public ActionResult AddOrder(Neighbor user,Order order)
        {
            UserDAL dbuser = new UserDAL();
            dbuser.AddOrder(user.Id, order);
            DisplayUserInformation info = new DisplayUserInformation(user);
            return View("ProfilePage", info);
        }
        public ActionResult AddOrderPage(Neighbor user,int recipe_id)
        {
            RecipeDAL dbrecipe = new RecipeDAL();
            Recipe recipe= dbrecipe.GetRecipe(recipe_id);
            ViewBag.user = user;
            ViewBag.recipe = recipe;
            return View("MakeAnOrder");
        }

    }
}