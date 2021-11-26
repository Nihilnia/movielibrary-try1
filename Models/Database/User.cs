using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMovie.Models.Database
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePic { get; set; }
        public List<Movie> Movies { get; set; }
    }
}