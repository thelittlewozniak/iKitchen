using onessaye.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onessaye.Models.POCO;

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
            }
            int? tmp=0;
            try
            {
                tmp = Convert.ToInt32(Request["Age"]);
                if(tmp<18 || tmp>150 || tmp==null)
                {
                    check = false;
                }
            }
            catch (Exception ex)
            {
                check = false;
            }
            if(check==true || check==false)
            {
                Cook myUser = new Cook();
                myUser.Age = Convert.ToInt32(Request["Age"]);
                myUser.Nickname = Request["Nickname"];
                myUser.LastName = Request["LastName"];
                myUser.Gender = Request["Gender"];
                myUser.Email = Request["Email"];
                myUser.FirstName = Request["FirstName"];
                myUser.DateRegister = DateTime.Now;
                myUser.Password = Request["password"];
                //reste a ajouter


                RegisterDAL regDal = new RegisterDAL();
                if(Request["Type"]=="Cook")
                {
                   regDal.AddCookDb(myUser);
                   ViewBag.test = "ok";
                }
            }


            return View();
        }
    }
}