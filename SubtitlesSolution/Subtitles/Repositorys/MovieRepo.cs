using Subtitles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subtitles.Repositorys
{
	public class MovieRepo
	{
		public Movie GetAllMovies()
		{
			var a = new Movie();
			a.ID = 1;
			a.Name = "KLISTINN";
			return a;
		}

		public void AddMovie(Movie m)
		{
			 //Context.
		}
	}
}