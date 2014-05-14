using Subtitles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subtitles.CombinedModel
{
	public class Everything
	{
		public IEnumerable<Movie> movie { get; set; }
		public IEnumerable<TvShow> tvShow { get; set; }
	}
}