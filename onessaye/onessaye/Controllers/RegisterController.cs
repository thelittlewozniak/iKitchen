using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }


          /*          public int Id { get; set; }
        [Required, MinLength(3), MaxLength(15), Display(Name = "Enter your nickname")]
        public string Nickname { get; set; }
        [Required, MinLength(4), MaxLength(15), Display(Name = "Enter your password")]
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime DateRegister { get; set; }*/
    }
}