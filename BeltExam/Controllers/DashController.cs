using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeltExam.Controllers
{

    public class DashController : Controller
    {
        private readonly DbConnector _dbConnector;

        public DashController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("dash")]
        public IActionResult Dash()
        {
            if(HttpContext.Session.GetInt32("id") != null){
                
                ViewBag.network = new Dictionary<string, object>();
                ViewBag.invitation = new Dictionary<string, object>();

                int? checkid = HttpContext.Session.GetInt32("id");
                int id = (int)checkid;
                string userQuery = $"SELECT * FROM users WHERE id = '{id}'";
                Dictionary<string, object> user = _dbConnector.Query(userQuery).SingleOrDefault();
                ViewBag.user = user;

                string networkQuery = $"SELECT name, users.id FROM users JOIN network ON users.id = network.connected WHERE network.users_id = '{id}';";
                List<Dictionary<string, object>> network = _dbConnector.Query(networkQuery).ToList();
                ViewBag.network = network;

                string inviteQuery = $"SELECT name, users.id, invites.id AS invite_id FROM users JOIN invites ON users.id = invites.requestor WHERE invites.user_id = {id};";
                List<Dictionary<string, object>> invitation = _dbConnector.Query(inviteQuery).ToList();
                ViewBag.invitation = invitation;
                return View("Dash");
            }
            return RedirectToAction("index", "Users");
        }
        [HttpGet]
        [Route("profile/{id}")]
        public IActionResult Profile(int id)
        {
            if(HttpContext.Session.GetInt32("id") != null){
                
                string userQuery = $"SELECT * FROM users WHERE id = '{id}'";
                Dictionary<string, object> user = _dbConnector.Query(userQuery).SingleOrDefault();
                ViewBag.user = user;
                return View("Profile");
            }
            return RedirectToAction("index", "Users");
        }
    }
}

