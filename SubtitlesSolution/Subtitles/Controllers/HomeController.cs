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
			IEnumerable<Movie> values = Movierepo.GetAllMovies();

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
			if (media.Season == 0)
			{
				Movie m = new Movie();
				// Verify that the user selected a file
				if (media.File != null && media.File.ContentLength > 0)
				{
					/*
					var fileName = Path.GetFileName(media.File.FileName);
					var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
					media.File.SaveAs(path);
					string FileData = "";
					using (StreamReader sr = new StreamReader(path))
					{
						while(sr.Peek() >= 0)
						{
							FileData += sr.ReadLine();
						}
					}
					*/

					var fileName = Path.GetFileName(media.File.FileName);

					var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
					BinaryReader b = new BinaryReader(media.File.InputStream);
					int LengthOfFile = unchecked((int)media.File.InputStream.Length);
					byte[] BinData = b.ReadBytes(LengthOfFile);
					string Resault = System.Text.Encoding.UTF8.GetString(BinData);
					m.SrtFile = Resault;
					//ef við viljum save-a fileinn á serverinn
					//media.File.SaveAs(path); 
				}


				m.Name = media.Name;
				m.ImdbUrl = media.ImdbUrl;
				m.dateTime = DateTime.Now;
				PostToServerMovie(m);
				// redirect back to the index action to show the form once again
			}
			else
			{
				TvShow m = new TvShow();
				if (m.Season < 0)
				{

				}
				m.Season = media.Season;
				m.Episode = media.Episode;
				// Verify that the user selected a file
				if (media.File != null && media.File.ContentLength > 0)
				{
					// extract only the fielname
					var fileName = Path.GetFileName(media.File.FileName);
					// store the file inside ~/App_Data/uploads folder
					var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
					BinaryReader b = new BinaryReader(media.File.InputStream);
					int LengthOfFile = unchecked((int)media.File.InputStream.Length);
					byte[] BinData = b.ReadBytes(LengthOfFile);
					string Resault = System.Text.Encoding.UTF8.GetString(BinData);
					m.SrtFile = Resault;
					media.File.SaveAs(path);
				}

				//
				m.Name = media.Name;
				m.ImdbUrl = media.ImdbUrl;
				m.dateTime = DateTime.Now;
				PostToServerTv(m);
				// redirect back to the index action to show the form once again

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