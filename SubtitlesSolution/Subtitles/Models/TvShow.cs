using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subtitles.Models
{
    public class TvShow : Movie
    {
        public int Season { get; set; }
        public int Episode { get; set; }
    }
}