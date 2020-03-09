using MyBrokenPage.UI.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBrokenPage.UI.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = ErrorMessages.FIELD_EMPTY)]
        public string Username { get; set; }

        [Required(ErrorMessage = ErrorMessages.FIELD_EMPTY)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrorMessages.FIELD_EMPTY)]
        [Display(Name = "Retype Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords not matching")]
        public string ConfirmPassword { get; set; }

        public ICollection<UserSecurityAnswerViewModel> SecurityAnswers { get; set; }
    }
}
