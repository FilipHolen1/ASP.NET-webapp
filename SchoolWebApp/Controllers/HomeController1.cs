using Microsoft.AspNetCore.Mvc;

namespace SchoolWebApp.Web.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
