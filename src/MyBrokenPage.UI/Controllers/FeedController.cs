using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Constants;
using System.Linq;
using System.Security.Claims;

namespace MyBrokenPage.UI.Controllers
{
    [Authorize]
    [Route(Routes.FeedController)]
    public class FeedController : Controller
    {
        [ViewData]
        public string UsernameViewData { get; set; }
        [ViewData]
        public string RoleViewData { get; set; }

        [HttpGet(Routes.FeedControllerIndex)]
        public IActionResult Index()
        {
            UsernameViewData = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            RoleViewData = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            return View();
        }
    }
}
