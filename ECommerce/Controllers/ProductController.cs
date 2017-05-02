using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private ECommerceContext _dbConnector;
    
        public ProductController(ECommerceContext connect)
        {
            _dbConnector = connect;
        }        
        // GET: /Home/
        [HttpGet]
        [Route("product")]
        public IActionResult Product()
        {
            ViewBag.allProducts = _dbConnector.products.ToList();
            return View("Product");
        }
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(Product newProduct)
        {
            Product check = _dbConnector.products.Where(prod => prod.ProductName == newProduct.ProductName || prod.Image == newProduct.Image).SingleOrDefault();
            if(check == null) {
                _dbConnector.products.Add(newProduct);
                _dbConnector.SaveChanges();
            }
            else {
                HttpContext.Session.SetString("error", "Sorry but this product already exists!");
            }
            return RedirectToRoute("Product");
        }
    }
}
