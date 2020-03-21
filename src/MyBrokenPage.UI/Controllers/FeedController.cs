using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Constants;

namespace MyBrokenPage.UI.Controllers
{
    [Authorize]
    [Route(Routes.FeedController)]
    public class FeedController : Controller
    {
        [HttpGet(Routes.FeedControllerIndex)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
