using Subtitles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subtitles.Repositorys
{
	public class MovieRepo
	{
		AppDataContext context = new AppDataContext();
		public IEnumerable<Movie> GetAllMovies()
		{
			var values = from s in context.Movies
						 orderby s.Name ascending
						 select s;

			return values;
		}
		public IEnumerable<Movie> GetTop10()
		{
			var values = (from s in context.Movies
						  orderby s.dateTime descending
						  where s.SrtFile == null
						  select s).Take(10);
			return values;
		}

		public void AddMovie(Movie m)
		{
			context.Movies.Add(m);
			context.SaveChanges();
		}
		public int GetLargestId()
		{
			var largest = (from s in context.Movies
						   orderby s.ID descending
						   select s.ID).FirstOrDefault();
			largest = largest + 1;
			return largest;

		}
	}
}