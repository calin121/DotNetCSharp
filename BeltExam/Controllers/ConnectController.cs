using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeltExam.Controllers
{

    public class ConnectController : Controller
    {
        private readonly DbConnector _dbConnector;

        public ConnectController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("allusers")]
        public IActionResult AllUsers()
        {
            if(HttpContext.Session.GetInt32("id") != null){

                string userQuery = $"SELECT name, users.id FROM users LEFT JOIN network ON users.id = network.users_id LEFT JOIN invites ON users.id = invites.user_id WHERE network.users_id IS NULL AND invites.user_id IS NULL;";
                // string userQuery = "SELECT * FROM users;";
                // List<Dictionary<string, object>> user = _dbConnector.Query(userQuery).ToList();
                var user = _dbConnector.Query(userQuery);
                ViewBag.user = user;
                return View("Connect");
            }
            return RedirectToAction("index", "Users");
        }
        [HttpGet]
        [Route("invite/{invitedid}")]
        public IActionResult Invite(int invitedid)
        {
            if(HttpContext.Session.GetInt32("id") != null){
                int? checkid = HttpContext.Session.GetInt32("id");
                int id = (int)checkid;
                string inviteQuery = $"INSERT INTO invites (requestor, user_id, created_at, updated_at) VALUES ('{id}', '{invitedid}', NOW(),  NOW());";
                _dbConnector.Execute(inviteQuery);
                return RedirectToAction("Dash", "Dash");
            }
            return RedirectToAction("index", "Users");
        }
        [HttpGet]
        [Route("accept/{invite_id}/{acceptedid}")]
        public IActionResult Accept(int acceptedid, int invite_id)
        {
            // Need to fix!
            if(HttpContext.Session.GetInt32("id") != null){
                int? checkid = HttpContext.Session.GetInt32("id");
                int id = (int)checkid;
                string inviteQuery = $"INSERT INTO network (network.connected, network.users_id, network.created_at, network.updated_at) VALUES ({acceptedid}, '{id}', NOW(), NOW()); DELETE FROM invites WHERE invites.id = '{invite_id}';";
                _dbConnector.Execute(inviteQuery);
                return RedirectToAction("Profile", "Dash");
            }
            return RedirectToAction("index", "Users");
        }
        [HttpGet]
        [Route("ignore/{invite_id}")]
        public IActionResult Ignore(int invite_id)
        {
            // Need to fix!
            if(HttpContext.Session.GetInt32("id") != null){
                int? checkid = HttpContext.Session.GetInt32("id");
                int id = (int)checkid;
                string inviteQuery = $"DELETE FROM invites WHERE invites.id = '{invite_id}';";
                _dbConnector.Execute(inviteQuery);
                return RedirectToAction("Profile", "Dash");
            }
            return RedirectToAction("index", "Users");
        }
    }
}