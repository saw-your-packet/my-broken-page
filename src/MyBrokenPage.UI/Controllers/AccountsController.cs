using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Converters;
using MyBrokenPage.UI.Constants;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.UI.ViewModels;
using MyBrokenPage.UI.Helpers;
using System.Threading.Tasks;
using System.Linq;
using MyBrokenPage.UI.Extensions;

namespace MyBrokenPage.UI.Controllers
{
    [Route(Routes.ACCOUNTS_CONTROLLER)]
    [Controller]
    public class AccountsController : Controller
    {
        private readonly IUserBll _userBll;
        private readonly ISecurityQuestionBll _securityQuestionBll;
        private readonly AuthenticationHelper _authenticationHandler;

        public AccountsController(IUserBll userBll, ISecurityQuestionBll securityQuestionBll, AuthenticationHelper authenticationHandler)
        {
            _userBll = userBll;
            _authenticationHandler = authenticationHandler;
            _securityQuestionBll = securityQuestionBll;
        }

        [HttpGet(Routes.ACCOUNTS_CONTROLLER_LOGIN)]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(Routes.ACCOUNTS_CONTROLLER_LOGIN)]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginViewModel);
            }

            var userLoginModel = userLoginViewModel.ToUserLoginModel();

            var userModel = _userBll.RetrieveUserByCredentials(userLoginModel);

            if (userModel == null)
            {
                ModelState.AddModelError(nameof(UserLoginViewModel.Password), ErrorMessages.LOGIN_INVALID_CREDENTIALS);

                return View(userLoginViewModel);
            }

            await _authenticationHandler.SignIn(userModel);

            return RedirectToAction(nameof(FeedController.Index), nameof(FeedController).Replace("Controller", string.Empty));
        }

        [HttpGet(Routes.ACCOUNTS_CONTROLLER_LOGOUT)]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Login));
            }

            await _authenticationHandler.SignOut();

            return RedirectToAction(nameof(Login));
        }

        [HttpGet(Routes.ACCOUNTS_CONTROLLER_REGISTER)]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
            }

            var securityQuestions = _securityQuestionBll.GetSecurityQuestions();
            var userRegisterViewModel = new UserRegisterViewModel
            {
                SecurityAnswers = securityQuestions.Select(x => x.ToUserSecurityAnswerViewModel())
                                                   .ToList()
            };

            return View(userRegisterViewModel);
        }

        [HttpPost(Routes.ACCOUNTS_CONTROLLER_REGISTER)]
        public IActionResult Register(UserRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _userBll.CreateAccount(model.ToUserRegisterModel());

            return RedirectToAction(nameof(Login));
        }
    }
}
