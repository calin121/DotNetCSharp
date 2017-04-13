using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogReg.Controllers
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
            if (ModelState.IsValid)
            {
                string insertQuery = $"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{newUser.first_name}','{newUser.last_name}', '{newUser.email}','{newUser.password}', NOW(), NOW()); SELECT * FROM users WHERE email = '{newUser.email}';";

                Dictionary<string, object> user = _dbConnector.Query(insertQuery).SingleOrDefault();
                
                HttpContext.Session.SetInt32("id", (int)user["id"]);
                HttpContext.Session.SetString("first_name", (string)user["first_name"]);
                ViewBag.id = HttpContext.Session.GetInt32("id");
                ViewBag.name = HttpContext.Session.GetString("first_name");
                return View("success");
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
                HttpContext.Session.SetString("first_name", (string)user["first_name"]);
                ViewBag.id = HttpContext.Session.GetInt32("id");
                ViewBag.name = HttpContext.Session.GetString("first_name");
                return View("success");
            }
            else
            {
                ViewBag.error = "Your email and password do not match";
                return View("Index");
            }


        }
        [HttpPost]
        [Route("success")]
        public IActionResult Success()
        {

            return View("Success");
        }
    }
}
