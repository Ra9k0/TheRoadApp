namespace TheRoadApp.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using TheRoadApp.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
