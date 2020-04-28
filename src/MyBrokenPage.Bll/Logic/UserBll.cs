using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.Bll.Converters;
using MyBrokenPage.Bll.Exceptions;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Models;
using System.Linq;

namespace MyBrokenPage.Bll.Logic
{
    public class UserBll : IUserBll
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ISecurityQuestionRepository _securityQuestionRepository;
        private readonly IUserSecurityAnswerRepository _userSecurityAnswerRepository;

        public UserBll(IUserRepository userRepository,
            IRoleRepository roleRepository,
            ISecurityQuestionRepository securityQuestionRepository,
            IUserSecurityAnswerRepository userSecurityAnswerRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _securityQuestionRepository = securityQuestionRepository;
            _userSecurityAnswerRepository = userSecurityAnswerRepository;
        }

        public UserModel RetrieveUserByCredentials(UserLoginModel userLoginModel)
        {
            if (userLoginModel == null)
            {
                return null;
            }

            var hashedPassword = PasswordManager.HashPassword(userLoginModel.Password);
            var user = _userRepository.GetUserByCredentials(userLoginModel.Username, hashedPassword);

            return user?.ToUserModel();
        }

        public void CreateAccount(UserCredentialsModel userCredentialsModel)
        {
            var isUsernameUsed = _userRepository.IsUsernameUsed(userCredentialsModel.Username);

            if (isUsernameUsed)
            {
                throw new ExceptionResourceConflict("Username used");
            }

            var securityQuestions = _securityQuestionRepository.GetAll();
            var allQuestionAreAnswered = securityQuestions.AsEnumerable().All(
                questionDal => userCredentialsModel.SecurityAnswers.Any(
                    answerUI => answerUI.SecurtityQuestion.Question == questionDal.Question));

            if (!allQuestionAreAnswered)
            {
                throw new ExceptionBusinessNotRespected("Questions not answered.");
            }

            var role = _roleRepository.GetById((int)RolesEnum.User);

            if (role == null)
            {
                throw new ExceptionResourceNotFound("Role not in databse.");
            }

            userCredentialsModel.Password = PasswordManager.HashPassword(userCredentialsModel.Password);
            var user = userCredentialsModel.ToUser(role, securityQuestions);

            _userRepository.Add(user);
            _userRepository.SaveChanges();
        }

        public bool IsUsernameUsed(string username)
        {
            return _userRepository.IsUsernameUsed(username);
        }

        public bool ResetForgottenPassword(UserCredentialsModel userCredentialsModel)
        {
            var user = _userRepository.GetUserByUsername(userCredentialsModel.Username);

            if (user == null)
            {
                throw new ExceptionResourceNotFound("User not found.");
            }

            var userSecurityAnswers = _userSecurityAnswerRepository.GetAnswersOfUser(user.Id);
            var isEligibleForPasswordReset = userSecurityAnswers.All(
                answerDal => userCredentialsModel.SecurityAnswers.Any(
                    answerBll => answerBll.SecurtityQuestion.Question == answerDal.SecurityQuestion.Question && answerBll.Answer == answerDal.Answer));

            if (!isEligibleForPasswordReset)
            {
                return false;
            }

            user.Password = PasswordManager.HashPassword(userCredentialsModel.Password);
            _userRepository.SaveChanges();

            return true;
        }

        public UserModel GetByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ExceptionBusinessNotRespected();
            }

            return _userRepository.GetUserByUsername(username)
                                  .ToUserModel();
        }
    }
}
