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

        public UserBll(IUserRepository userRepository, IRoleRepository roleRepository, ISecurityQuestionRepository securityQuestionRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _securityQuestionRepository = securityQuestionRepository;
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

        public void CreateAccount(UserRegisterModel userRegisterModel)
        {
            var isUsernameUsed = _userRepository.IsUsernameUsed(userRegisterModel.Username);

            if (isUsernameUsed)
            {
                throw new ExceptionResourceConflict("Username used");
            }

            var securityQuestions = _securityQuestionRepository.GetAll();
            var allQuestionAreAnswered = securityQuestions.AsEnumerable().All(
                questionDal => userRegisterModel.SecurityAnswers.Any(
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

            userRegisterModel.Password = PasswordManager.HashPassword(userRegisterModel.Password);
            var user = userRegisterModel.ToUser(role, securityQuestions);

            _userRepository.Add(user);
            _userRepository.SaveChanges();
        }
    }
}
