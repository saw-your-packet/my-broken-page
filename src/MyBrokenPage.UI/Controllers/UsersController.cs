using FileTypeChecker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.Models;
using MyBrokenPage.UI.Constants;
using MyBrokenPage.UI.Converters;
using MyBrokenPage.UI.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace MyBrokenPage.UI.Controllers
{
    [Route(Routes.UsersController)]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserBll _userBll;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileUploadHelper _fileUploadHelper;

        public UsersController(IUserBll userBll, IWebHostEnvironment webHostEnvironment, IFileUploadHelper fileUploadHelper)
        {
            _userBll = userBll;
            _webHostEnvironment = webHostEnvironment;
            _fileUploadHelper = fileUploadHelper;
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
        public IActionResult UploadProfilePicture(UserProfileViewModel userProfileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("MyProfile", userProfileViewModel);
            }

            using var stream = userProfileViewModel.Image.OpenReadStream();

            bool checkMagicNumberOwnImpl = _fileUploadHelper.IsExtensionAllowed(
                CheckExtensionMethodEnum.MagicNumberOwnImplementation, stream, userProfileViewModel.Image.FileName
                );
            bool checkFilename = _fileUploadHelper.IsExtensionAllowed(
                CheckExtensionMethodEnum.ExtensionFromFileName, stream, userProfileViewModel.Image.FileName
                );
            bool checkNuget = _fileUploadHelper.IsExtensionAllowed(
                CheckExtensionMethodEnum.FileTypeCheckerNuget, stream, userProfileViewModel.Image.FileName
                );

            if (!checkFilename)
            {
                return BadRequest("File not supported");
            }

            var imageName = userProfileViewModel.Image.FileName;
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            _userBll.AddProfilePictureName(username, imageName);
            _fileUploadHelper.SaveImage(stream, $"{_webHostEnvironment.WebRootPath}/{GeneralConstants.UploadsRelativePath}/{imageName}");

            return RedirectToAction(Names.UsersControllerMyProfile);
        }
    }
}
