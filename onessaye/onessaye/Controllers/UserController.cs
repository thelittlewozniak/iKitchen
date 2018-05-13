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
    public class UserController : Controller
    {
        // GET: Cook
        public ActionResult ProfilePage(User user)
        {
            DisplayUserInformation info = new DisplayUserInformation(user);
            return View(info);
        }
    }
}