using MyBrokenPage.Dal.Models;
using MyBrokenPage.Models;
using System.Collections.Generic;
using System.Linq;

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

        public static IEnumerable<UserSecurityAnswer> ConvertAndMapSecurityAnswers(
            this IEnumerable<UserSecurityAnswerModel> userSecurityAnswers,
            IEnumerable<SecurityQuestion> securityQuestions)
        {
            return userSecurityAnswers.Select(
                userSecurityAnswer => new UserSecurityAnswer
                {
                    Answer = userSecurityAnswer.Answer,
                    SecurityQuestion = securityQuestions.FirstOrDefault(
                        securityQuestion => securityQuestion.Question == userSecurityAnswer.SecurtityQuestion.Question)
                });
        }
    }
}
