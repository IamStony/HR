using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HvadSagdiHann.Models
{
    public class Movie
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string ImdbUrl { get; set; }
		public DateTime DateOfBirth { get; set; }

		public Movie( )
		{
			DateOfBirth = DateTime.Now;
		}
	}
}