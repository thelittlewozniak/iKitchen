using onessaye.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onessaye.Models.POCO;
using System.Security.Cryptography;

namespace onessaye.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register()
        {
            bool check=true;
            
            if(Request["Nickname"]== Request["FirstName"]|| Request["LastName"]== Request["FirstName"] || Request["LastName"]== Request["Nickname"])
            {
                check = false;
                ViewBag.test = "Your name can't be your pseudo.";
            }
            int? tmp=0;
            try
            {
                tmp = Convert.ToInt32(Request["Age"]);
                if(tmp<18 || tmp>150 || tmp==null)
                {
                    check = false;
                    ViewBag.test = "You can't be less than 0 years and more than 150.";
                }
            }
            catch (Exception ex)
            {
                check = false;
                ViewBag.test = "Your age must be in number.";
            }
            try
            {
                tmp = Convert.ToInt32(Request["DoorNumber"]);
                if (tmp == null)
                {
                    check = false;
                    ViewBag.test = "You must have a door number.";
                }
            }
            catch (Exception ex)
            {
                check = false;
                ViewBag.test = "Your door number must contain only numbers.";
            }
            if (check==true)
            {
                

                RegisterDAL regDal = new RegisterDAL();
                if(Request["Type"]=="Cook")
                {
                    Cook myUser = new Cook();
                    myUser.Age = Convert.ToInt32(Request["Age"]);
                    myUser.Nickname = Request["Nickname"];
                    myUser.LastName = Request["LastName"];
                    myUser.Gender = Request["Gender"];
                    myUser.Email = Request["Email"];
                    myUser.FirstName = Request["FirstName"];
                    myUser.DateRegister = DateTime.Now;
                    myUser.Password = Request["password"]; // a crypter
                    myUser.City = Request["City"];
                    myUser.DoorNumber = Request["DoorNumber"];
                    myUser.Street = Request["Street"];
                    regDal.AddCookDb(myUser);
                    ViewBag.test = "myUser.Nickname Bienvenue !";
                }
                else
                {
                    Neighbor myUser = new Neighbor();
                    myUser.Age = Convert.ToInt32(Request["Age"]);
                    myUser.Nickname = Request["Nickname"];
                    myUser.LastName = Request["LastName"];
                    myUser.Gender = Request["Gender"];
                    myUser.Email = Request["Email"];
                    myUser.FirstName = Request["FirstName"];
                    myUser.DateRegister = DateTime.Now;
                    myUser.Password = Request["password"]; // a crypter
                    myUser.City = Request["City"];
                    myUser.DoorNumber = Request["DoorNumber"];
                    myUser.Street = Request["Street"];
                    regDal.AddUserDb(myUser);
                    ViewBag.test = "myUser.Nickname Bienvenue !";

                }
            }


            return View();
        }
    }
}