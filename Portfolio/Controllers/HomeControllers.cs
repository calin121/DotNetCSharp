using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

 
namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        [Route("Projects")]
        public IActionResult Projects()
        {
            return View();
        }  
    }
}