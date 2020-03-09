using MyBrokenPage.Models;
using MyBrokenPage.UI.ViewModels;

namespace MyBrokenPage.UI.Extensions
{
    public static class SecurityQuestionExtensions
    {
        public static UserSecurityAnswerViewModel ToUserSecurityAnswerViewModel(this SecurityQuestionModel securityQuestionModel)
        {
            return new UserSecurityAnswerViewModel
            {
                SecurityQuestion = securityQuestionModel.ToSecurityQuestionViewModel()
            };
        }

        public static SecurityQuestionViewModel ToSecurityQuestionViewModel(this SecurityQuestionModel securityQuestionModel)
        {
            return new SecurityQuestionViewModel
            {
                Id = securityQuestionModel.Id,
                Question = securityQuestionModel.Question
            };
        }
    }
}
