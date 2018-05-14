using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onessaye.Models.DAL;
using onessaye.Models.POCO;
using onessaye.Models.EXCEPTIONS;

namespace onessaye.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Nickname, string Password)
        {
            List<string> errors = new List<string>();
            UserDAL dal = new UserDAL();
            try
            {
                User user = dal.GetUser(Nickname);
                if (user.Password == Password)
                {
                    return RedirectToAction("ProfilePage", "User", user);
                }
                else
                {
                    errors.Add("The password entered is incorrect");
                    ViewBag.Error = errors;
                    return View("Index");
                }
            }
            catch(UnableToLogInException ex)
            {
                errors.Add(ex.Message);
                errors.Add(ex.CauseOfError);
                errors.Add(ex.ErrorTimeStamp.ToString());
                ViewBag.Error = errors;
                return View("Index");
            }
            catch(Exception ex)
            {
                errors.Add("An internal error has occurred");
                errors.Add("Please try again later");
                errors.Add(ex.Message);
                return View("Index");
            }
        }
    }
}