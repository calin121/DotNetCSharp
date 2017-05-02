using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class DashController : Controller
    {
        private ECommerceContext _dbConnector;
    
        public DashController(ECommerceContext connect)
        {
            _dbConnector = connect;
        }        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Dash()
        {
            
            List<User> look = _dbConnector.users.ToList();
            System.Console.WriteLine(look);
            return View("Dash");
        }
    }
}
