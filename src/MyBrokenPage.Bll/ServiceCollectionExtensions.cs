using Microsoft.Extensions.DependencyInjection;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.Bll.Logic;

namespace MyBrokenPage.Bll
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyBrokenPageBll(this IServiceCollection services)
        {
            services.AddScoped<IUserBll, UserBll>();
            services.AddScoped<ISecurityQuestionBll, SecurityQuestionBll>();
            services.AddScoped<IPostsBll, PostsBll>();

            return services;
        }
    }
}
