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
		public IEnumerable<TvShow> GetAllTvShows()
		{
			var values = from s in context.TvShows
						 orderby s.Name ascending
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