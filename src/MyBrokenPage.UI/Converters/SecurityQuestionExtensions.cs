using MyBrokenPage.Models;
using MyBrokenPage.UI.ViewModels;

namespace MyBrokenPage.UI.Converters
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

        public static UserSecurityAnswerModel ToUserSecurityAnswerModel(this UserSecurityAnswerViewModel userSecurityAnswerViewModel)
        {
            return new UserSecurityAnswerModel
            {
                SecurtityQuestion = userSecurityAnswerViewModel.SecurityQuestion.ToSecurityQuestionModel(),
                Answer = userSecurityAnswerViewModel.Answer
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

        public static SecurityQuestionModel ToSecurityQuestionModel(this SecurityQuestionViewModel securityQuestionViewModel)
        {
            return new SecurityQuestionModel
            {
                Id = securityQuestionViewModel.Id,
                Question = securityQuestionViewModel.Question
            };
        }
    }
}
