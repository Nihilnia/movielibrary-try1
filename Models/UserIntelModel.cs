using ProjectMovie.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMovie.Models
{
    public class UserIntelModel
    {
        public User User { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Category> Categories { get; set; }
    }
}