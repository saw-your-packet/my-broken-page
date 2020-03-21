using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Attributes;
using MyBrokenPage.UI.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBrokenPage.UI.ViewModels
{
    public class UserCredentialsViewModel
    {
        [Required(ErrorMessage = ErrorMessages.FieldEmpty)]
        [Remote(action: Names.AccountsControllerVerifyUsername, controller: Names.Accounts)]
        public string Username { get; set; }

        [Required(ErrorMessage = ErrorMessages.FieldEmpty)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrorMessages.FieldEmpty)]
        [Display(Name = "Retype Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = ErrorMessages.PasswordsDoesntMatch)]
        public string ConfirmPassword { get; set; }

        [QuestionsAnswered]
        public ICollection<UserSecurityAnswerViewModel> SecurityAnswers { get; set; }
    }
}
