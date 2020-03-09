using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Constants;

namespace MyBrokenPage.UI.Controllers
{
    [Route(Routes.HOME_CONTROLLER)]
    public class HomeController : Controller
    {
        [HttpGet(Routes.HOME_CONTROLLER_INDEX)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
