﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyBrokenPage.UI.Helpers;

namespace MyBrokenPage.UI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyBrokenPageUI(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.Cookie.Name = "MyBorkenPage.Auth";
                    });
            services.AddAuthorization();
            services.AddControllersWithViews();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AuthenticationHelper>();

            return services;
        }
    }
}