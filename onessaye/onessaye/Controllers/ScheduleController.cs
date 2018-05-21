using onessaye.Models.DAL;
using onessaye.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onessaye.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index(string id)
        {
            int idCook = Convert.ToInt32(id);
            ScheduleDAL schedules = new ScheduleDAL();
            ViewBag.Recipe = schedules.GetSchedulesPerUser(idCook);
            return View("ScheduleView");
        }
    }
}