using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace CallingCard.Controllers
{
    public class HelloController : Controller
    {
        
        [HttpGet]
        [RouteAttribute("")]
        public string Index()
        {
            // Method body
            return "Hello World!";
        }

        [HttpGet]
        [RouteAttribute("name/{name}/{favnum}")]
        public JsonResult Name(string name, int favnum)
        {
            // Method body
            object obj = new {
                myName = name,
                myAge = favnum
            };
            return Json(obj);
        }

        [HttpGet]
        [RouteAttribute("info/{fname}/{lname}/{favenum}/{favcolor}")]
        public JsonResult Friends(string fname, string lname, int favenum, string favcolor)
        {
            // Method body
            var annonymousObj = new {
                FirstName = fname,
                LastName = lname,
                FavoriteNumber = favenum,
                FavoriteColor = favcolor
            };
            return Json(annonymousObj);
        }
    }
}