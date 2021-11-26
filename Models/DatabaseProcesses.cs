using ProjectMovie.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMovie.Models
{
    public static class DatabaseProcesses
    {
        // USER INTEL MODEL
        public static UserIntelModel UserIntel(string Username)
        {
            var theUser = new UserIntelModel();

            using (var DB = new GottaRunContext())
            {
                var getUser = DB.Users.Where(u => u.Username.ToLower() == Username).FirstOrDefault();
                var getMovies = DB.Movies.Where(m => m.UserID == getUser.ID).ToList();
                var getCategories = new List<Category>();
                foreach (var f in getMovies) //check this out later.
                {
                    getCategories = DB.Categories.Where(c => c.MovieID == f.ID).ToList();
                }

                theUser.User = getUser;
                theUser.Movies = getMovies;
                theUser.Categories = getCategories;
            }

            return theUser;
        }

        //User log-In combination control
        public static UserIntelModel LoginControl(User incomingUser)
        {
            var theUser = new UserIntelModel();
            using (var DB = new GottaRunContext())
            {
                var daUser = DB.Users.Where(f => f.Username == incomingUser.Username).FirstOrDefault();

                if (daUser != null)
                {
                    if(daUser.Password == incomingUser.Password)
                    {
                        theUser.User = daUser;
                    }
                }
                else
                {
                    theUser.User = null;
                }
            }

            return theUser;
        }


        //NEW USER REGISTRATION
        public static void AddNewUser(User incomingUser)
        {
            using (var DB = new GottaRunContext())
            {
                var newUser = new User()
                {
                    Username = incomingUser.Username,
                    Password = incomingUser.Password,
                    FirstName = incomingUser.FirstName,
                    LastName = incomingUser.LastName
                };

                DB.Users.Add(newUser);
                DB.SaveChanges();
            }
        }

        // UPDATE USER INTEL
        public static void UpdateUserInfo(string userName, string firstName, string lastName, string passWord, string profilePicture)
        {
            using (var DB = new GottaRunContext())
            {
                var theUser = DB.Users.Where(f => f.Username == userName).FirstOrDefault();

                if(theUser != null)
                {
                    if (firstName != "")
                    {
                        theUser.FirstName = firstName;
                        if(lastName != "")
                        {
                            theUser.LastName = lastName;
                            
                        }
                        else
                        {
                            theUser.LastName = lastName;
                        }
                    }
                    else
                    {
                        theUser.FirstName = theUser.FirstName;
                    }
                    
                    
                    theUser.Password = passWord;
                    theUser.ProfilePic = profilePicture;

                    DB.SaveChanges();
                }
            }
        }

        public static void DeleteUser(string userName)
        {
            using (var DB = new GottaRunContext())
            {
                var daUser = DB.Users.Where(f => f.Username == userName).FirstOrDefault();

                if (daUser != null)
                {
                    DB.Users.Remove(daUser);
                    DB.SaveChanges();
                }
            }
        }



        // NEW MOVIE
        public static void AddNewMovie(string userName, string movieName)
        {
            var newMovie = new Movie();
            var theUser = new User();

            using (var DB = new GottaRunContext())
            {
                theUser = DB.Users.Where(f => f.Username.ToLower() == userName).FirstOrDefault();

                newMovie = new Movie() { UserID = theUser.ID, Name = movieName };

                DB.Movies.Add(newMovie);
                DB.SaveChanges();
            }
        }

        //DELETE MOVIE
        public static void DeleteMovie(string movieName)
        {
            using (var DB = new GottaRunContext())
            {
                var theMovie = DB.Movies.Where(f => f.Name == movieName).FirstOrDefault();
                if(theMovie != null)
                {
                    DB.Movies.Remove(theMovie);
                    DB.SaveChanges();
                }
            }
        }

        // GET MOVIE THINGS
        public static Movie GetMovieByName(string movieName)
        {
            var theMovie = new Movie();

            using (var DB = new GottaRunContext())
            {
                var daMovie = DB.Movies.Where(f => f.Name.ToLower() == movieName).FirstOrDefault();

                if(theMovie != null)
                {
                    theMovie = daMovie;
                }
            }
            return theMovie;
        }


        // NEW CATEGORY

        public static void AddNewCategory(int movieID, string categoryName)
        {
            using (var DB = new GottaRunContext())
            {
                var daMovie = DB.Movies.Find(movieID);
                var newCategory = new Category() { Name = categoryName, MovieID = movieID };
                DB.Categories.Add(newCategory);
                DB.SaveChanges();
            }
        }
    }
}