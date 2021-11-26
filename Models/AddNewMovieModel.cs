using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMovie.Models
{
    public class AddNewMovieModel
    {
        public int UserID { get; set; }
        public string MovieName { get; set; }
        public string MovieCategory { get; set; }
    }
}