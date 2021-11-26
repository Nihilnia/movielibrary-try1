using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMovie.Models.Database
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public List<Category> Categories { get; set; }

        //FKey
        public int UserID { get; set; }
    }
}