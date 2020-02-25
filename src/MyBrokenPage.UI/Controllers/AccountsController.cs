using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Converters;
using MyBrokenPage.UI.Constants;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.UI.ViewModels;
using MyBrokenPage.UI.Helpers;
using System.Threading.Tasks;

namespace MyBrokenPage.UI.Controllers
{
    [Route(Routes.ACCOUNTS_CONTROLLER)]
    [Controller]
    public class AccountsController : Controller
    {
        [ViewData]
        public string Title => PageTitles.LOGIN;

        private readonly IUserBll _userBll;
        private readonly AuthenticationHelper _authenticationHandler;

        public AccountsController(IUserBll userBll, AuthenticationHelper authenticationHandler)
        {
            _userBll = userBll;
            _authenticationHandler = authenticationHandler;
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
    }
}
