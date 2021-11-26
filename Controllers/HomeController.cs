using ProjectMovie.Models;
using ProjectMovie.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMovie.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User newuser)
        {
            DatabaseProcesses.AddNewUser(newuser);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Index(User incomingUser)
        {
            string returnView = "";
            string returnController = "";

            var theUser = new UserIntelModel();

            if(DatabaseProcesses.LoginControl(incomingUser).User != null)
            {
                returnView = "Welcome";
                returnController = "User";
                theUser = DatabaseProcesses.UserIntel(incomingUser.Username);
            }
            else
            {
                returnView = "FailedLogin";
                returnController = "Index";
            }
            return View(returnView, theUser);
            
        }
    }
}