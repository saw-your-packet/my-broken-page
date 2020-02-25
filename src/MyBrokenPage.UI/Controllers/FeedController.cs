using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Constants;

namespace MyBrokenPage.UI.Controllers
{
    [Authorize]
    [Route(Routes.FEED_CONTROLLER)]
    public class FeedController : Controller
    {
        [HttpGet(Routes.FEED_CONTROLLER_INDEX)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
