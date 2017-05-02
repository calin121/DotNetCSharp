using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeltExam.Controllers
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
            string usercheck = $"SELECT * FROM users WHERE email = '{newUser.email}'";
            Dictionary<string, object> newusercheck = _dbConnector.Query(usercheck).SingleOrDefault();

            if (newusercheck == null){
                if (ModelState.IsValid)
                {
                    string insertQuery = $"INSERT INTO users (name, description, email, password, created_at, updated_at) VALUES ('{newUser.name}','{newUser.description}', '{newUser.email}','{newUser.password}', NOW(), NOW()); SELECT * FROM users WHERE email = '{newUser.email}';";

                    Dictionary<string, object> user = _dbConnector.Query(insertQuery).SingleOrDefault();
                    
                    HttpContext.Session.SetInt32("id", (int)user["id"]);
                    HttpContext.Session.SetString("name", (string)user["name"]);
                    return RedirectToAction("dash", "Dash");
                }
                else
                {
                    ViewBag.errors = ModelState.Values;
                }
            }
            else {
                ViewBag.error2 = "Your email has already been registered! Please log in below, or use a different email.";
            }
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password)
        {
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

                HttpContext.Session.SetInt32("id", (int)user["id"]);
                HttpContext.Session.SetString("name", (string)user["name"]);
                return RedirectToAction("dash", "Dash");
            }
            else
            {
                ViewBag.error = "Your email and password do not match";
                return View("Index");
            }
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout(int id)
        {
            HttpContext.Session.Clear();
        
            return View("Index");
        }
    }
}
