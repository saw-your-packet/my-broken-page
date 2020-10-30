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

        [HttpGet(Routes.FeedControllerDelete)]
        public IActionResult DeletePost([FromQuery]int id)
        {
            var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            _postsBll.Delete(id, username);

            return NoContent();
        }

        [HttpGet(Routes.FeedControllerAddPost)]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost(Routes.FeedControllerAddPost)]
        public IActionResult AddPost([FromForm] PostViewModel post)
        {
            post.Username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            _postsBll.Add(post.ToModel());

            return RedirectToAction(Names.FeedControllerIndex);
        }

        [HttpGet(Routes.FeedControllerPost)]
        public IActionResult GetPost([FromQuery]int id)
        {
            var postModel = _postsBll.GetById(id);

            if (postModel == null)
            {
                var secondRedirect = $"{this.Request.Scheme}://{this.Request.Host}/{Routes.FeedController}";

                return RedirectToAction(Names.HomeControllerCustomNotFound, Names.Home, new { urlRedirect = secondRedirect });
            }

            var postViewModel = postModel.ToViewModel();

            return View(postViewModel);
        }
    }
}
