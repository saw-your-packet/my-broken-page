using FileTypeChecker.Web.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MyBrokenPage.UI.ViewModels
{
    public class UserProfileViewModel
    {
        public string Username { get; set; }

        public string ProfilePictureName { get; set; }

        public string Role { get; set; }

        [Required]
        //[AllowImageOnly]
        public IFormFile Image { get; set; }
    }
}
