using Subtitles.Models;
using Subtitles.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Subtitles.Controllers
{
    public class HomeController : Controller
    {
        MovieRepo repo = new MovieRepo();
        public ActionResult Index()
        {
            IEnumerable<Movie> values = repo.GetAllNews();

            return View(values);
        }
        public ActionResult Requesting()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Translate(FormCollection formData)
        {
            return RedirectToAction("Translate");
        }

        public ActionResult Translate()
        {
            //ViewBag.Message = "Your about page.";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}