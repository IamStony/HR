using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Subtitles.Models
{
	public class AppDataContext : DbContext
	{
		public DbSet<Movie> Movies { get; set; }
		public DbSet<TvShow> TvShows { get; set; }
	}
}