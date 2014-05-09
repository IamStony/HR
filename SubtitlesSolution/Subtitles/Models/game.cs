using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subtitles.Models
{
	public class game
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int MaxPlayers { get; set; }
		public int MinPlayers { get; set; }
	}
}