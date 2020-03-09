using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.Bll.Converters;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBrokenPage.Bll.Logic
{
    public class SecurityQuestionBll : ISecurityQuestionBll
    {
        private readonly ISecurityQuestionRepository _securityQuestionRepository;

        public SecurityQuestionBll(ISecurityQuestionRepository securityQuestionRepository)
        {
            _securityQuestionRepository = securityQuestionRepository;
        }

        public ICollection<SecurityQuestionModel> GetSecurityQuestions()
        {
            return _securityQuestionRepository.GetAll()
                                              .Select(x => x.ToSecurityQuestionModel())
                                              .ToList();
        }
    }
}
