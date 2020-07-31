using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.UI.Converters;
using MyBrokenPage.UI.Constants;
using MyBrokenPage.UI.ViewModels;
using MyBrokenPage.UI.Helpers;

namespace MyBrokenPage.UI.Controllers
{
    [Route(Routes.AccountsController)]
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

        [HttpGet(Routes.AccountsControllerLogin)]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(Routes.AccountsControllerLogin)]
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
                ModelState.AddModelError(nameof(UserLoginViewModel.Password), ErrorMessages.LoginInvalidCredentials);

                return View(userLoginViewModel);
            }

            await _authenticationHandler.SignIn(userModel);

            return RedirectToAction(Names.FeedControllerIndex, Names.Feed);
        }

        [HttpGet(Routes.AccountsControllerLogout)]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _authenticationHandler.SignOut();
            }

            return RedirectToAction(Names.AccountsControllerLogin);
        }

        [HttpGet(Routes.AccountsControllerRegister)]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(Names.HomeControllerIndex, Names.Home);
            }

            var securityQuestions = _securityQuestionBll.GetSecurityQuestions();
            var userRegisterViewModel = new UserCredentialsViewModel
            {
                SecurityAnswers = securityQuestions.Select(x => x.ToUserSecurityAnswerViewModel())
                                                   .ToList()
            };

            return View(userRegisterViewModel);
        }

        [HttpPost(Routes.AccountsControllerRegister)]
        public IActionResult Register(UserCredentialsViewModel userCredentialsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userCredentialsViewModel);
            }

            _userBll.CreateAccount(userCredentialsViewModel.ToUserCredentialsModel());

            return RedirectToAction(Names.AccountsControllerLogin);
        }

        [HttpGet(Routes.AccountsControllerForgotPassword)]
        public IActionResult ForgotPassword()
        {
            var userResetPasswordModel = new UserCredentialsViewModel
            {
                SecurityAnswers = _securityQuestionBll.GetSecurityQuestions().Select(x => x.ToUserSecurityAnswerViewModel())
                                                                             .ToList()
            };

            return View(userResetPasswordModel);
        }

        [HttpPost(Routes.AccountsControllerForgotPassword)]
        public IActionResult ForgotPassword(UserCredentialsViewModel userCredentialsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userCredentialsViewModel);
            }

            var isResetSuccessfully = _userBll.ResetForgottenPassword(userCredentialsViewModel.ToUserCredentialsModel());

            if (isResetSuccessfully)
            {
                return RedirectToAction(Names.AccountsControllerLogin);
            }

            ModelState.AddModelError(nameof(UserCredentialsViewModel.SecurityAnswers), ErrorMessages.SecurityAnsweredWrong);

            return View(userCredentialsViewModel);
        }

        [AcceptVerbs("GET", "POST")]
        [Route(Routes.AccountsControllerVerifyUsername)]
        public IActionResult VerifyUsername(string username)
        {
            if (!_userBll.IsUsernameUsed(username))
            {
                return NotFound($"Username {username} not found.");
            }

            return Json(true);
        }
    }
}
