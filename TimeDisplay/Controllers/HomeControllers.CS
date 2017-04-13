using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

 
namespace TimeDisplay.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // DateTime CurrentTimes = DateTime.Now;
            // var context = new {
            //     CurrentTime = CurrentTimes
            // };
            
            return View();
            //OR
            // return View("Index");
            // //Both of these returns will render the same view (You only need one!)
        }      
    }
}