using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subtitles.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImdbUrl { get; set; }
        //public int LanguageID { get; set; }
        public string SrtFile { get; set; }
    }
}