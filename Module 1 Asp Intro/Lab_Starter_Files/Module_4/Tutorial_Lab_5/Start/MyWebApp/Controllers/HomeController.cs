using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View(DataSource.Countries);
        }
    }
}