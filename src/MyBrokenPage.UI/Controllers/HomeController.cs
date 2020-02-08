using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Utils;

namespace MyBrokenPage.UI.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get { return PageTitles.HOME; } }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
