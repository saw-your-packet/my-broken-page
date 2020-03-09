using MyBrokenPage.UI.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyBrokenPage.UI.ViewModels
{
    public class UserSecurityAnswerViewModel
    {
        public SecurityQuestionViewModel SecurityQuestion { get; set; }

        [Required(ErrorMessage = ErrorMessages.FIELD_EMPTY)]
        public string Answer { get; set; }
    }
}
