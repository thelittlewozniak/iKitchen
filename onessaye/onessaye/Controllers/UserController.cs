﻿using System;
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
    public class UserController : Controller
    {
        // GET: Cook
        public ActionResult ProfilePageCook(Cook user)
        {
            UserDAL dal = new UserDAL();
            ViewBag.ListRecipes = dal.GetRecipes(user);
            DisplayUserInformation info = new DisplayUserInformation(user);
            return View("ProfilePage",info);
        }
        public ActionResult ProfilePageNeighbor(Neighbor user)
        {
            DisplayUserInformation info = new DisplayUserInformation(user);
            return View("ProfilePage", info);
        }
        public ActionResult DeleteRecipe(int id_recipe)
        {
            UserDAL dal = new UserDAL();
            dal.DeleteRecipe(id_recipe);
            return RedirectToRoute("DeletedRecipe");
        }
    }
}