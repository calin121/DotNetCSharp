using System.Collections.Generic;
using System.Linq;
using LogReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wall.Controllers
{

    public class UsersController : Controller
    {
        private readonly DbConnector _dbConnector;

        public UsersController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(User newUser)
        {
            ViewBag.errors = new List<string>();
            // If the information is all vaild
            if (ModelState.IsValid)
            {
                // If the email does not already exist
                string checkemail = $"SELECT * FROM users WHERE email = '{newUser.email}';";
                Dictionary<string, object> isthere = _dbConnector.Query(checkemail).SingleOrDefault();
                if (isthere == null) {
                    // Create/Register a new user and pull the user id and name, then log them in
                    string insertQuery = $"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{newUser.first_name}','{newUser.last_name}', '{newUser.email}','{newUser.password}', NOW(), NOW()); SELECT * FROM users WHERE email = '{newUser.email}';";

                    Dictionary<string, object> user = _dbConnector.Query(insertQuery).SingleOrDefault();
                    // Saving name and user_id in session
                    HttpContext.Session.SetInt32("id", (int)user["user_id"]);
                    HttpContext.Session.SetString("first_name", (string)user["first_name"]);
                    HttpContext.Session.SetString("success", "registered");

                    return RedirectToAction("Success", "WallController");
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
        public IActionResult Login(string email, string password)
        {
            // pulling user from db
            string insertQuery = $"SELECT * FROM users WHERE email = '{email}'";
            Dictionary<string, object> user = _dbConnector.Query(insertQuery).SingleOrDefault();

            if (user == null)
            {
                ViewBag.errors = new List<string>();
                ViewBag.error = "Your email does not exist!";

                return View("Index");
            }
            else if (password == (string)user["password"])
            {
                // Saving name and user_id in session
                HttpContext.Session.SetInt32("id", (int)user["user_id"]);
                HttpContext.Session.SetString("first_name", (string)user["first_name"]);
                HttpContext.Session.SetString("success", "logged in");
                return RedirectToAction("Wall", "Wall");
            }
            else
            {
                ViewBag.error = "Your email and password do not match";
                return View("Index");
            }


        }
    }
}
