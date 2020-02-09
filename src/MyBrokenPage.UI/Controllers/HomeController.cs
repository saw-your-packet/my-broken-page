using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Utils.Constants;

namespace MyBrokenPage.UI.Controllers
{
    [Route(Routes.HOME_CONTROLLER)]
    public class HomeController : Controller
    {
        [ViewData]
        public string Title => PageTitles.HOME;

        [HttpGet(Routes.HOME_CONTROLLER_INDEX)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
