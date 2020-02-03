﻿using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Converters;
using MyBrokenPage.UI.Utils;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.UI.ViewModels;

namespace MyBrokenPage.UI.Controllers
{
    [Route("")]
    [Controller]
    public class AccountsController : Controller
    {
        private readonly IUserBll _userBll;

        public AccountsController(IUserBll userBll)
        {
            _userBll = userBll;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = userLoginViewModel.ToUserModel();

            var loginResult = _userBll.VerifyCredentials(userModel);

            if (loginResult == false)
            {
                return Unauthorized(ErrorMessages.LOGIN_INVALID_CREDENTIALS);
            }

            return Ok(SuccessMessages.LOGIN_COMPLETED);
        }
    }
}
