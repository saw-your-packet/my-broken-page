using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyBrokenPage.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyBrokenPage.UI.Helpers
{
    public class AuthenticationHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SignIn(UserModel userModel)
        {
            var authScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            var claimsPrincipal = CreateClaimsPrincipal(userModel);
            var authProperties = GetAuthenticationProperties();

            await _httpContextAccessor.HttpContext.SignInAsync(authScheme, claimsPrincipal, authProperties);
        }

        private ClaimsPrincipal CreateClaimsPrincipal(UserModel userModel)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Role, userModel.Role.Name),
                new Claim(ClaimTypes.NameIdentifier, userModel.Username)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return new ClaimsPrincipal(claimsIdentity);
        }

        private AuthenticationProperties GetAuthenticationProperties()
        {
            return new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(6)
            };
        }
    }
}
