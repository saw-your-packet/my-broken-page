using FileTypeChecker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyBrokenPage.Bll.Contracts;
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
        public IActionResult UploadProfilePicture(UserProfileViewModel userProfileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("MyProfile", userProfileViewModel);
            }

            bool isAllowedMagicNumber = IsExtensionAllowed(userProfileViewModel.Image);
            var extension = Regex.Match(userProfileViewModel.Image.FileName, "\\.\\w+$").Groups[0]?.Value;
            bool isAllowedFileExtension = SupportedFileFormats.Extensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
            bool isAllowedNugetFileChecker = FileTypeValidator.IsImage(userProfileViewModel.Image.OpenReadStream());

            if (!isAllowedMagicNumber || !isAllowedFileExtension || !isAllowedNugetFileChecker)
            {
                return BadRequest("File not supported");
            }

            //TODO
            // make bll function for saving the image on /images/uploads and insert the name of the image in db
            var imageName = userProfileViewModel.Image.FileName;
            var username= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            _userBll.AddProfilePictureName(username, imageName);
            SaveImage(userProfileViewModel.Image); 
            
            return RedirectToAction(Names.UsersControllerMyProfile);
        }
        private void SaveImage(IFormFile formfile)
        {
            var path = GeneralConstants.UploadsRelativePath + formfile.FileName;
            using (var stream = new FileStream(path, FileMode.Create))
            {
                formfile.CopyTo(stream);
            }
        }
        private bool IsExtensionAllowed(IFormFile formFile)
        {
            var isExtensionAllowed = false;
            var maxBytesToRead = SupportedFileFormats.FileSignatures.Max(fileSignature => fileSignature.Length);
            byte[] buffer = new byte[maxBytesToRead];

            using var stream = formFile.OpenReadStream();
            stream.Read(buffer, 0, maxBytesToRead);

            foreach (var fileSignature in SupportedFileFormats.FileSignatures)
            {
                isExtensionAllowed = true;

                for (int i = 0; i < fileSignature.Length; i++)
                {
                    if (fileSignature[i] != buffer[i])
                    {
                        isExtensionAllowed = false;
                        break;
                    }
                }

                if (isExtensionAllowed)
                {
                    break;
                }
            }
            
            return isExtensionAllowed;
        }
    }
}
