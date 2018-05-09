using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onessaye.Views.ViewClasses;
using onessaye.Models.POCO;

namespace onessaye.Controllers
{
    public class CookController : Controller
    {
        // GET: Cook
        public ActionResult ProfilePage()
        {
            Cook c = new Cook { Nickname="Bgdu87", Address="Charleroi, Rue de la Boucherie, 90", Email="bg@hotmail.com",
                FirstName="Jean", LastName="Bouvier", Gender="M", Age=45, DateRegister=DateTime.Today};
            DisplayCookInformations info = new DisplayCookInformations(c);
            return View(info);
        }
    }
}