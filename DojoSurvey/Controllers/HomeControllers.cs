using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

 
namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [Route("Process")]
        public IActionResult Process(string name, string location, string language, string comment)
        {
            // Do something with form input
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;

            return View("Result");
        }
    }
}