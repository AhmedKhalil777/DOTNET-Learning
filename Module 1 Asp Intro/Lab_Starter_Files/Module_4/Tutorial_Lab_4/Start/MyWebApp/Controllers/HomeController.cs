using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            var roles = new List<Transformer>();
            roles.Add(new Transformer(1, "Optimus Prime", "Earth", "Blue"));
            roles.Add(new Transformer(2, "Bumblebee", "Earth", "Yellow"));
            roles.Add(new Transformer(3, "Starscream", "Cybertron", "Red"));
            roles.Add(new Transformer(4, "Soundwave", "Cybertron", "Purple"));
            return View(roles);
        }
    }
}