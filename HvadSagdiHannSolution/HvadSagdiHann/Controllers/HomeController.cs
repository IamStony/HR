using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HvadSagdiHann.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Requesting()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        } 

        public ActionResult Translate()
        {
            //ViewBag.Message = "Your about page.";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}