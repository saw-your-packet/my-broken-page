using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.UI.Constants;
using MyBrokenPage.UI.Converters;
using System.Linq;
using System.Security.Claims;

namespace MyBrokenPage.UI.Controllers
{
    [Route(Routes.UsersController)]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserBll _userBll;

        public UsersController(IUserBll userBll) 
        {
            _userBll = userBll;
        }

        [HttpGet(Routes.UsersControllerMyProfile)]
        public IActionResult MyProfile()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userModel = _userBll.GetByUsername(username);
            var userProfileViewModel = userModel.ToUserProfileViewModel();

            return View(userProfileViewModel);
        }

        [HttpPost(Routes.UsersControllerUploadProfilePicture)]
        public IActionResult UploadProfilePicture(IFormFile formFile)
        {
            return RedirectToAction(Names.UsersControllerMyProfile);
        }
    }
}
