using Subtitles.Models;
using Subtitles.Repositorys;
using System;
using System.Collections.Generic;
using System.IO;
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
		public ActionResult Translate(Movie e)
		{
			Movie c = new Movie();
			c.Name = e.Name;
			c.ImdbUrl = e.ImdbUrl;
			System.Diagnostics.Debug.WriteLine(e);
			c.dateTime = DateTime.Now;
			e.ID = repo.GetLargestId();
			c.ID = e.ID;
			repo.AddMovie(c);
			//return Json(c, JsonRequestBehavior.AllowGet);
			return RedirectToAction("Translate");
		}

		public ActionResult Translate()
		{
			//ViewBag.Message = "Your about page.";

			return View();
		}
		[HttpPost]
		public ActionResult Index(HttpPostedFileBase file)
		{
			// Verify that the user selected a file
			if (file != null && file.ContentLength > 0)
			{
				// extract only the fielname
				var fileName = Path.GetFileName(file.FileName);
				// store the file inside ~/App_Data/uploads folder
				var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
				file.SaveAs(path);
			}
			// redirect back to the index action to show the form once again
			return RedirectToAction("Index");
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
	}
}