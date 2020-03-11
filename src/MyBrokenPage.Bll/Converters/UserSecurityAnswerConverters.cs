using MyBrokenPage.Dal.Models;
using MyBrokenPage.Models;

namespace MyBrokenPage.Bll.Converters
{
    public static class UserSecurityAnswerConverters
    {
        public static UserSecurityAnswer ToUserSecurityAnswer(this UserSecurityAnswerModel userSecurityAnswerModel)
        {
            return new UserSecurityAnswer
            {
                Answer = userSecurityAnswerModel.Answer,
                SecurityQuestion = userSecurityAnswerModel.SecurtityQuestion.ToSecurityQuestion()
            };
        }
    }
}
