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
                string getMsgs = "SELECT message_id, message, messages.user_user_id, messages.created_at, users.first_name, users.last_name FROM users JOIN messages ON users.user_id = messages.user_user_id ORDER BY created_at DESC;";
                var allMsgs = _dbConnector.Query(getMsgs);
                // Put the messages into the ViewBag
                ViewBag.messages = allMsgs;
                
                // Query the db for all comments and place them into the ViewBag
                string getCmts = "SELECT comment, comments.user_user_id, message_id, comments.created_at, first_name, last_name FROM users JOIN messages ON user_id = user_user_id JOIN comments ON message_id = message_message_id;";
                 
                var allCmts = _dbConnector.Query(getCmts);
                // Put the comments into the ViewBag
                ViewBag.comments = allCmts;

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
                // send message to the db                
                string setMsgInDb = $"INSERT INTO messages (message, created_at, updated_at, user_user_id) VALUES ('{message}',NOW(), NOW(), '{HttpContext.Session.GetInt32("id")}');";
                System.Console.WriteLine(setMsgInDb);
                _dbConnector.Execute(setMsgInDb);
                return RedirectToAction("Wall");
            }
            return View("~/Views/Users/Index.cshtml");
        }
        [HttpPost]
        [Route("createcmt/{id}")]
        public IActionResult Createcmt(string comment, int id)
        {
            ViewBag.errors = new List<string>();
            if(HttpContext.Session.GetInt32("id") != null) {
                // send comment to the db and retrieve all messages                
                string setMsgInDb = $"INSERT INTO comments (comment, created_at, updated_at, user_user_id, message_message_id) VALUES ('{comment}',NOW(), NOW(), '{HttpContext.Session.GetInt32("id")}', '{id}');";
                System.Console.WriteLine(setMsgInDb);
                _dbConnector.Execute(setMsgInDb);
                return RedirectToAction("Wall");
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
        [HttpPost]
        [Route("deletemsg/{msgID}")]
        public IActionResult DeleteMsg(int msgID)
        {
            ViewBag.errors = new List<string>();
            if(HttpContext.Session.GetInt32("id") != null) {
                
                string deleteCmtsAndMsgs = $"DELETE FROM comments WHERE message_message_id = {msgID}; DELETE FROM messages WHERE message_id = {msgID};";
                _dbConnector.Execute(deleteCmtsAndMsgs);
                                 
                return RedirectToAction("Wall");
            }
            return View("~/Views/Users/Index.cshtml");
        }
    }
}
