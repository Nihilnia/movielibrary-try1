using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMovie.Models.Database
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Movie Movie { get; set; }

        //FKey
        public int MovieID { get; set; }
    }
}