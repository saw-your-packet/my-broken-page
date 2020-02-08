﻿using Microsoft.Extensions.DependencyInjection;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.Bll.Logic;

namespace MyBrokenPage.Bll
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollectionBll(this IServiceCollection services)
        {
            services.AddScoped<IUserBll, UserBll>();

            return services;
        }
    }
}