using MyBrokenPage.Dal.Models;
using MyBrokenPage.Models;

namespace MyBrokenPage.Bll.Converters
{
    public static class SecurityQuestionConverters
    {
        public static SecurityQuestionModel ToSecurityQuestionModel(this SecurityQuestion securityQuestion)
        {
            return new SecurityQuestionModel
            {
                Id = securityQuestion.Id,
                Question = securityQuestion.Question
            };
        }

        public static SecurityQuestion ToSecurityQuestion(this SecurityQuestionModel securityQuestionModel)
        {
            return new SecurityQuestion
            {
                Id = securityQuestionModel.Id,
                Question = securityQuestionModel.Question,
            };
        }
    }
}
