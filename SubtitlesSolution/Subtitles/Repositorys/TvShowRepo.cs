using Subtitles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subtitles.Repositorys
{
	public class TvShowRepo
	{
		AppDataContext context = new AppDataContext();
		public IEnumerable<Movie> GetAllTvShows()
		{
			var values = from s in context.Movies
						 orderby s.dateTime descending
						 select s;

			return values;
		}
		public void AddTvShow(TvShow e)
		{
			context.TvShows.Add(e);
			context.SaveChanges();
		}

	}
}