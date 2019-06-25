using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyWebAPP.Models;

namespace MyWebAPP.Controllers {
    public class ProductController : Controller {
        public IActionResult ShowAll() {
            ViewData["Heading"] = "All Products";
            var products = new List<Product>();
            products.Add(new Product { ID = 101, Name = "Apple", Price = 1.1f });
            products.Add(new Product { ID = 202, Name = "Bike", Price = 2.2f });
            products.Add(new Product { ID = 303, Name = "Calculator", Price = 3.3f});
            return View(products);
        }
    }
}
