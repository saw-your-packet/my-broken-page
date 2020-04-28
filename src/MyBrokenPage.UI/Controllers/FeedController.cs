using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.Models;
using MyBrokenPage.UI.Constants;
using MyBrokenPage.UI.Converters;
using MyBrokenPage.UI.ViewModels;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace MyBrokenPage.UI.Controllers
{
    [Authorize]
    [Route(Routes.FeedController)]
    public class FeedController : Controller
    {
        private readonly HtmlEncoder _htmlEncoder;
        private readonly IPostsBll _postsBll;

        public FeedController(HtmlEncoder htmlEncoder, IPostsBll postsBll)
        {
            _htmlEncoder = htmlEncoder;
            _postsBll = postsBll;
        }

        [HttpGet(Routes.FeedControllerIndex)]
        public IActionResult Index([FromQuery]SearchViewModel searchViewModel)
        {
            var posts = _postsBll.GetAll(searchViewModel.SearchInput)
                                 .Select(p => p.ToViewModel());

            if (searchViewModel?.SearchInput != null)
            {
                searchViewModel.SearchSafe = _htmlEncoder.Encode(searchViewModel.SearchInput);
            }

            return View(new FeedPageViewModel { Posts = posts, SearchObject = searchViewModel });
        }

        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            _postsBll.Delete(id, username);

            return NoContent();
        }

        [HttpPost("")]
        public IActionResult Add([FromForm] PostViewModel post)
        {
            post.Username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            _postsBll.Add(post.ToModel());

            return Ok();
        }
    }
}
