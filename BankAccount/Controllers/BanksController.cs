using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankAccount.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Controllers
{
    public class BanksController : Controller {
        private BankAccountContext _dbConnector;
    
        public BanksController(BankAccountContext connect)
        {
            _dbConnector = connect;
        }        
        // GET: /Home/
        [HttpGet]
        [Route("dash")]
        public IActionResult Dash()
        {
            int? id = HttpContext.Session.GetInt32("Id");
            ViewBag.errors = new List<string>();
            User curUser = _dbConnector.users.Where(user => user.UserId == (int)id).SingleOrDefault();
            
            List<Transaction> curTrans = _dbConnector.transactions.Where(tran => tran.UserId == (int)id).OrderByDescending(x => x.CreatedAt).ToList();
            if(HttpContext.Session.GetInt32("Id") != null){
                ViewBag.id = HttpContext.Session.GetInt32("Id");
                ViewBag.balance = curUser.Balance;
                ViewBag.transactions = curTrans;
                ViewBag.name = HttpContext.Session.GetString("FirstName");
                // User AllUsers = _dbConnector.users.SingleOrDefault();
                return View("Dash");
            }
            return RedirectToAction("Index", "Users");
        }
        [HttpPost]
        [Route("transaction")]
        public IActionResult Transacted(Transaction trans)
        {
            ViewBag.errors = new List<string>();
            int? id = HttpContext.Session.GetInt32("Id");
            User curUser = _dbConnector.users.Where(x => x.UserId == (int)id).SingleOrDefault();
            trans.UserId = (int)id;
            
            if(HttpContext.Session.GetInt32("Id") != null){
                if(curUser.Balance + trans.Amount > 0) {
                    curUser.Balance += trans.Amount;
                    _dbConnector.transactions.Add(trans);
                    _dbConnector.SaveChanges();
                    return RedirectToAction("Dash");
                }
                else {
                    TempData["error"] = "Sorry! It looks like you do not have sufficient funds for this transaction!";
                    return RedirectToAction("Dash");
                }
            }
            else {
            return RedirectToAction("Index", "Users");
            }
        }
        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            ViewBag.errors = new List<string>();
            // TempData["error"] = "string";
            if(HttpContext.Session.GetInt32("Id") != null){
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Users");
            }
            return RedirectToAction("Index", "Users");;
        }
    }
}