using ProjectMovie.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMovie.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Welcome()
        {
            return View();
        }
        
        public ActionResult Dashboard(string Username)
        {
            var model = DatabaseProcesses.UserIntel(Username);
            return View(model);
        }


        [HttpGet]
        public ActionResult AddNewMovie(string Username)
        {
            var model = DatabaseProcesses.UserIntel(Username);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddNewMovie(string Username, string movieName)
        {
            var model = DatabaseProcesses.UserIntel(Username);
            DatabaseProcesses.AddNewMovie(Username, movieName);
            return View("Dashboard", model);
        }

        [HttpGet]
        public ActionResult AddNewCategory(string Username, string movieName)
        {
            var model = DatabaseProcesses.UserIntel(Username);
            ViewBag.MovieName = movieName;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddNewCategory(string Username, string movieName, string Category)
        {
            DatabaseProcesses.AddNewCategory(DatabaseProcesses.GetMovieByName(movieName).ID, Category);
            var model = DatabaseProcesses.UserIntel(Username);
            return View("Dashboard", model);
        }

        public ActionResult DeleteMovie(string Username, string MovieName)
        {
            DatabaseProcesses.DeleteMovie(MovieName);
            var model = DatabaseProcesses.UserIntel(Username);
            return View("Dashboard", model);
        }

        [HttpGet]
        public ActionResult Profile(string Username)
        {
            var model = DatabaseProcesses.UserIntel(Username);
            return View(model);
        }

        [HttpPost]
        public ActionResult Profile(string Username, string firstName, string lastName, string passWord, HttpPostedFileBase file)
        {
            var pFileName = "";

            if(file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                if(extension == ".jpg" || extension == ".png")
                {

                    var fileName = Path.GetFileName(file.FileName);
                    pFileName = fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/UserPictures"), fileName);

                    file.SaveAs(path);

                    DatabaseProcesses.UpdateUserInfo(Username, firstName, lastName, passWord, pFileName);
                }
                else
                {
                    ViewData["Message"] = "Please select a picture file.";
                }

                
            }
            else
            {
                var mxodel = DatabaseProcesses.UserIntel(Username);
                DatabaseProcesses.UpdateUserInfo(Username, firstName, lastName, passWord, profilePicture: mxodel.User.ProfilePic);
            }

            var model = DatabaseProcesses.UserIntel(Username);
            
            
            return View(model);

        }

        public ActionResult DeleteProfile(bool isDelete, string userName)
        {
            DatabaseProcesses.DeleteUser(userName);
            return RedirectToAction("Index", "Home");
        }
    }
}