using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("add")]
        public IActionResult AddQuote(string name, string quote)
        {
            string fname = name;
            string quotes = quote;

            string insertQuery = $"INSERT INTO quotes (name, quote, created_at) VALUES ('{fname}','{quotes}', NOW());";
            
            DbConnector.Execute(insertQuery);
            
            return View("Index");
        }
        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            // -- Query --
            string tableName = "quotes";
            string query = $"SELECT * FROM {tableName};";
            List<Dictionary<string, object>> quotes = DbConnector.Query(query);
            ViewBag.quotes = quotes;
            return View("Quote");
        }
    }
}


