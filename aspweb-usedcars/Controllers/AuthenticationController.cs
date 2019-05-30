using aspweb_usedcars.DataAbstractionLayer;
using aspweb_usedcars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspweb_usedcars.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult GoRegister()
        {
            return View("Register");
        }

        public ActionResult LoginUser()
        {
            var username = Request.Params["username"];
            var password = Request.Params["password"];

            var repo = new UserDAL();
            User user = repo.GetUser(username);
            if (user == null)
            {
                ViewData["error"] = "invalid username";
                return View("Error");
            }
            if (user.password != password)
            {
                ViewData["error"] = "invalid password";
                return View("Error");
            }
            Session.Add("username", username);
            return RedirectToAction("", "Main");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("", "Authentication");
        }

        public ActionResult Register()
        {
            var username = Request.Params["username"];
            var password1 = Request.Params["password1"];
            var password2 = Request.Params["password2"];

            var repo = new UserDAL();
            User user = repo.GetUser(username);

            if (user != null)
            {
                ViewData["error"] = "username already exists";
                return View("Error");
            }
            if (password1 != password2)
            {
                ViewData["error"] = "passwords don't match";
                return View("Error");
            }
            repo.AddUser(username, password1);
            return RedirectToAction("", "Authentication");

        }
    }
}