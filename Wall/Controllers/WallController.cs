using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wall.Controllers
{

    public class WallController : Controller
    {
        private readonly DbConnector _dbConnector;

        public WallController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("Wall")]
        public IActionResult Wall()
        {   
            ViewBag.errors = new List<string>();
        // Check to see if someone is logged in before entering the wall
            if(HttpContext.Session.GetInt32("id") != null) {
                // then save their information from session into the ViewBag
                ViewBag.id = HttpContext.Session.GetInt32("id");
                ViewBag.name = HttpContext.Session.GetString("first_name");
                ViewBag.success = HttpContext.Session.GetString("success");

                // Query the db for all messages and place them into the ViewBag
                string getMsgs = "SELECT * FROM messages;";
                var allMsgs = _dbConnector.Query(getMsgs);
                // Put the messages into the ViewBag
                ViewBag.messages = allMsgs;
                // Query the db for all comments and place them into the ViewBag

                
                return View("Wall");
            }
            else {
                return View ("~/Views/Users/Index.cshtml");
            }
        }
        [HttpPost]
        [Route("createmsg")]
        public IActionResult Createmsg(string message)
        {
            ViewBag.errors = new List<string>();
            if(HttpContext.Session.GetInt32("id") != null) {
                // send message to the db and retrieve all messages                
                string setMsgInDb = $"INSERT INTO messages (message, created_at, updated_at, user_user_id) VALUES ('{message}',NOW(), NOW()), '{HttpContext.Session.GetInt32("id")}';";
                _dbConnector.Execute(setMsgInDb);
                return RedirectToAction("Wall");
            }
            return View("~/Views/Users/Index.cshtml");
        }
        [HttpPost]
        [Route("createcmt")]
        public IActionResult Createcmt()
        {
            ViewBag.errors = new List<string>();
            if(HttpContext.Session.GetInt32("id") != null) {
                
               
                return View("Wall");
            }
            return View("~/Views/Users/Index.cshtml");
        }
        [HttpPost]
        [Route("logout")]
        public IActionResult LogOut()
        {
            ViewBag.errors = new List<string>();
            HttpContext.Session.Clear();
            return View("~/Views/Users/Index.cshtml");
        }
    }
}
