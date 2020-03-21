using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Constants;

namespace MyBrokenPage.UI.Controllers
{
    [Route(Routes.HomeController)]
    public class HomeController : Controller
    {
        [HttpGet(Routes.HomeControllerIndex)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
