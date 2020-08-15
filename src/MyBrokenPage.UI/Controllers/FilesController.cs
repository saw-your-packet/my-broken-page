using FileTypeChecker.Web.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.UI.Constants;
using System;
using System.IO;
using System.Security.Claims;

namespace MyBrokenPage.UI.Controllers
{
    [Authorize]
    [Route(Routes.FilesController)]
    public class FilesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileManagementHelper _fileManagementHelper;

        public FilesController(IWebHostEnvironment webHostEnvironment, IFileManagementHelper fileManagementHelper)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileManagementHelper = fileManagementHelper;
        }

        [HttpGet(Routes.FilesControllerIndex)]
        public IActionResult Index()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, "users-storage", username);
            var folderModel = _fileManagementHelper.GetFolderModel(fullPath);

            return View(folderModel);
        }

        [HttpGet(Routes.FilesControllerDownloadImage)]
        public IActionResult DownloadImage([FromQuery] string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return RedirectToAction(Names.HomeControllerCustomNotFound, Names.Home);
            }

            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, "users-storage", username, fileName);

            var file = _fileManagementHelper.DownloadImage(fullPath);
            var contentType = "application/octet-stream";
            var newFileName = $"{Guid.NewGuid()}.jpg";

            return File(file, contentType, newFileName);
        }

        [HttpPost(Routes.FilesControllerUploadZip)]
        public IActionResult UploadZip([AllowArchiveOnly]IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var basePath = Path.Combine(_webHostEnvironment.WebRootPath, "users-storage", username);

            _fileManagementHelper.UploadZip(basePath, file.OpenReadStream());

            return RedirectToAction(nameof(Index));
        }
    }
}
