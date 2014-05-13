using Subtitles.Models;
using Subtitles.Repositorys;
using Subtitles.ReverseViewModel;
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
		MovieRepo Movierepo = new MovieRepo();
		TvShowRepo Tvrepo = new TvShowRepo();
		public ActionResult Index()
		{
			IEnumerable<Movie> values = Movierepo.GetTop10();

			return View(values);
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
		[HttpPost]
		public ActionResult Index(Transfering media)
		{
			
			string resault = "";
			// Verify that the user selected a file
			if (media.File != null && media.File.ContentLength > 0)
			{

				var fileName = Path.GetFileName(media.File.FileName);
				var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
				BinaryReader b = new BinaryReader(media.File.InputStream);
				int LengthOfFile = unchecked((int)media.File.InputStream.Length);
				byte[] BinData = b.ReadBytes(LengthOfFile);
				resault = System.Text.Encoding.Default.GetString(BinData);
                //ef við viljum save-a fileinn á serverinn
				//media.File.SaveAs(path); 
			}
			if(media.Season == 0)
			{
				Movie m = new Movie();
				m.Name = media.Name;
				m.ImdbUrl = media.ImdbUrl;
				m.SrtFile = resault;
				m.dateTime = DateTime.Now;
				PostToServerMovie(m);
			}
			else
			{
				TvShow m = new TvShow();
				m.Season = media.Season;
				m.Episode = media.Episode;
				m.Name = media.Name;
				m.ImdbUrl = media.ImdbUrl;
				m.SrtFile = resault;
				m.dateTime = DateTime.Now;
				PostToServerTv(m);
			}
			
			return RedirectToAction("Index");
}
			
		public void PostToServerMovie(Movie e)
		{
				 Movierepo.AddMovie(e);
		}
		public void PostToServerTv(TvShow e)
		{
			Tvrepo.AddTvShow(e);
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
	}
}