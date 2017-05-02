using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        private ECommerceContext _dbConnector;
    
        public OrderController(ECommerceContext connect)
        {
            _dbConnector = connect;
        }        
        // GET: /Home/
        [HttpGet]
        [Route("order")]
        public IActionResult Dash()
        {
            return View("Order");
        }
    }
}
