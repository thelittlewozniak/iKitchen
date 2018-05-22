using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onessaye.Models.DAL;
using onessaye.Models.POCO;
using onessaye.Models.EXCEPTIONS;

//Bisconti Flavian && Zaretti Quentin

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
            RsaDAL rsa = new RsaDAL();
            try
            {
                Cook cook = dal.GetCook(Nickname);
                string tmp;
                
                if (cook is null)
                {
                    Neighbor neighbor = dal.GetNeighbor(Nickname);
                    //User is a Neighbor
                    tmp = neighbor.Password;
                    tmp = tmp = rsa.Decryption(tmp);
                    if (tmp == Password)
                    {
                        return RedirectToAction("ProfilePageNeighbor", "User", neighbor);
                    }
                    else
                    {
                        errors.Add("The password entered is incorrect");
                        ViewBag.Error = errors;
                        return View("Index");
                    }
                }
                //User is a Cook
                else
                {
                    tmp = cook.Password;
                    tmp = rsa.Decryption(tmp);
                    if (tmp == Password)
                    {
                        return RedirectToAction("ProfilePageCook", "User", cook);
                    }
                    else
                    {
                        errors.Add("The password entered is incorrect");
                        ViewBag.Error = errors;
                        return View("Index");
                    }
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
        public ActionResult LoginForOrder(string Nickname, string Password,string recipe_id)
        {
            List<string> errors = new List<string>();
            UserDAL dal = new UserDAL();
            try
            {
                Cook cook = dal.GetCook(Nickname);
                if (cook is null)
                {
                    Neighbor neighbor = dal.GetNeighbor(Nickname);
                    //User is a Neighbor
                    if (neighbor.Password == Password)
                    {
                        RecipeDAL dbrecipe = new RecipeDAL();
                        Recipe recipe = dbrecipe.GetRecipe(Convert.ToInt32(recipe_id));
                        ViewBag.Recipe = recipe;
                        return View("MakeAnOrder");
                    }
                    else
                    {
                        errors.Add("The password entered is incorrect");
                        ViewBag.Error = errors;
                        return View("LoginOrder");
                    }
                }
                //User is a Cook
                else
                {
                    errors.Add("A cook cannot make an order");
                    ViewBag.Error = errors;
                    return View("LoginOrder");
                }
            }
            catch (UnableToLogInException ex)
            {
                errors.Add(ex.Message);
                errors.Add(ex.CauseOfError);
                errors.Add(ex.ErrorTimeStamp.ToString());
                ViewBag.Error = errors;
                return View("LoginOrder");
            }
            catch (Exception ex)
            {
                errors.Add("An internal error has occurred");
                errors.Add("Please try again later");
                errors.Add(ex.Message);
                return View("LoginOrder");
            }
        }

    }
}