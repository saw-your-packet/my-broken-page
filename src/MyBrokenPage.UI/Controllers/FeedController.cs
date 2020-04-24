using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Constants;
using MyBrokenPage.UI.ViewModels;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Html;







namespace MyBrokenPage.UI.Controllers
{
    [Authorize]
    [Route(Routes.FeedController)]
    public class FeedController : Controller
    {
        HtmlEncoder _htmlEncoder;
        public FeedController(HtmlEncoder htmlEncoder)
        {
            _htmlEncoder = htmlEncoder;
        }
        [ViewData]
        public string UsernameViewData { get; set; }
        [ViewData]
        public string RoleViewData { get; set; }

        [HttpGet(Routes.FeedControllerIndex)]
        public IActionResult Index([FromQuery]SearchViewModel searchViewModel)
        {
            UsernameViewData = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            RoleViewData = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            if (searchViewModel?.SearchInput != null)
            {
                searchViewModel.SearchSafe = _htmlEncoder.Encode(searchViewModel.SearchInput);
            }

            return View(searchViewModel);
        }


    }
}
