using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;
using Microsoft.AspNetCore.Http;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller {
        private RESTauranterContext _dbConnector;
    
        public HomeController(RESTauranterContext connect)
        {
            _dbConnector = connect;
        }        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {            
           
            return View();
        }
        [HttpPost]
        [Route("review")]
        public IActionResult review(Reviews myreview, string restaurant_name)
        {
            System.Console.WriteLine(myreview);
            System.Console.WriteLine(restaurant_name);
            _dbConnector.review.Add(myreview);
            _dbConnector.SaveChanges();
            return View("Index");
        }
        [HttpGet]
        [Route("allreviews")]
        public IActionResult AllReviews()
        {
            List<Reviews> AllUsers = _dbConnector.review.OrderByDescending(date => date.created_at).ToList();
            ViewBag.AllUsers = AllUsers;
            ViewBag.s = "s";
            return View("Review");
        }
    }
}
