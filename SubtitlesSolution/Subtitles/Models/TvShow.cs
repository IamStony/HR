using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subtitles.Models
{
    public class TvShow : BaseModel
    {
        public int Season { get; set; }
        public int Episode { get; set; }
    }
}