using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventPlanner.Models;

namespace EventPlanner.Controllers
{
    public class UsersController : Controller {
        private EventPlannerContext _dbConnector;
    
        public UsersController(EventPlannerContext connect)
        {
            _dbConnector = connect;
        }        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            // List<User> AllUsers = _dbConnector.user.ToList();
            return View("Index");
        }
        [HttpGet]
        [Route("alreadyregistered")]
        public IActionResult AlreadyRegistered()
        {
            ViewBag.errors = new List<string>();
            // List<User> AllUsers = _dbConnector.user.ToList();
            return View("Login");
        }
        [HttpGet]
        [Route("backtogister")]
        public IActionResult BackToRegister()
        {
            ViewBag.errors = new List<string>();
            // List<User> AllUsers = _dbConnector.user.ToList();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model, User newUser)
        {
            ViewBag.errors = new List<string>();
            // If the information is all vaild
            if (ModelState.IsValid)
            {
                // If the email does not already exist
                User checkemail = _dbConnector.users.Where(x => x.Email == newUser.Email).SingleOrDefault();
                if (checkemail == null) {
                    // Create/Register a new user and pull the user id and name, then log them in
                    _dbConnector.users.Add(newUser);
                    _dbConnector.SaveChanges();
                    // Saving name and user_id in session
                    User checkuser = _dbConnector.users.Where(x => x.Email == newUser.Email).SingleOrDefault();
                    HttpContext.Session.SetInt32("Id", (int)checkuser.UserId);
                    HttpContext.Session.SetString("FirstName", (string)checkuser.FirstName);

                    return RedirectToAction("events", "Events");
                }
                else {
                    ViewBag.newerrors = "This email already exists!";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.errors = ModelState.Values;
            }
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string Email, string Password)
        {
            // pulling user from db
            User newUser = _dbConnector.users.Where(x => x.Email == Email).SingleOrDefault();
            if (newUser == null)
            {
                ViewBag.error = "Your email does not exist!";

                return View("Login");
            }
            else if (Password == (string)newUser.Password)
            {
                // Saving name and user_id in session
                HttpContext.Session.SetInt32("Id", (int)newUser.UserId);
                return RedirectToAction("events", "Events");
            }
            else
            {
                ViewBag.error = "Your email and password do not match";
                return View("Index");
            }
        }
    }
}
