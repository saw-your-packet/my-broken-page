using MyBrokenPage.Models;
using System.Collections.Generic;

namespace MyBrokenPage.Bll.Contracts
{
    public interface ISecurityQuestionBll
    {
        ICollection<SecurityQuestionModel> GetSecurityQuestions();
    }
}
