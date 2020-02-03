using Microsoft.AspNetCore.Mvc;

namespace MyBrokenPage.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
