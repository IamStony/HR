using Subtitles.CombinedModel;
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
		public ActionResult Index(string searchString)
		{
			//IEnumerable<Movie> values = Movierepo.GetTop10();
			var everything = new Everything();
			everything.movie = Movierepo.GetAllMovies();
			everything.tvShow = Tvrepo.GetAllTvShows();
			if (!String.IsNullOrEmpty(searchString))
			{
				everything.movie = everything.movie.Where(m => m.Name.Contains(searchString));
				everything.tvShow = everything.tvShow.Where(t => t.Name.Contains(searchString));
			}
			return View(everything);
			//return View();
		}
		public ActionResult Requesting()
		{
			//ViewBag.Message = "Your application description page.";

			var movieTop10 = Movierepo.GetTop10();
			return View(movieTop10);
		}
		public ActionResult Translate()
		{
			//ViewBag.Message = "Your about page.";
			return View();
		}
		[HttpPost]
		public ActionResult FileUpload(Transfering media)
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