using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce.Controllers
{
    public class CustomerController : Controller
    {
        private ECommerceContext _dbConnector;
    
        public CustomerController(ECommerceContext connect)
        {
            _dbConnector = connect;
        }        
        // GET: /Home/
        [HttpGet]
        [Route("customer")]
        public IActionResult Customer()
        {
            ViewBag.error2 = "Sorry, our database does not containe that name!";
            List<User> allUsers = _dbConnector.users.ToList();
            ViewBag.error = HttpContext.Session.GetString("error");
            ViewBag.allUsers = allUsers;
            return View("Customer");
        }
        [HttpPost]
        [Route("add")]
        public IActionResult AddUser(User newUser)
        {
            User check = _dbConnector.users.Where(user => user.Name == newUser.Name).SingleOrDefault();
            if (check == null){
                if(ModelState.IsValid){
                    _dbConnector.users.Add(newUser);
                    _dbConnector.SaveChanges();
                    return RedirectToAction("Customer");
                }
            }
            else {
                HttpContext.Session.SetString("error", "This name already exists!");
            }
            return RedirectToAction("Customer");
        }
        [HttpPost]
        [Route("search")]
        public IActionResult Search(string search)
        {   
            
            ViewBag.allUsers = _dbConnector.users.Where(user => user.Name == search);
            return View("Customer");
        }
        [HttpPost]
        [Route("delete/{userId}")]
        public IActionResult Delete(string userId)
        {
            User getUser = _dbConnector.users.Where(user => user.UserId == Int32.Parse(userId)).SingleOrDefault();
            if (getUser != null){
                _dbConnector.users.Remove(getUser);
                _dbConnector.SaveChanges();
                return RedirectToAction("Customer");
            }
            return RedirectToAction("Customer");
        }
    }
}
