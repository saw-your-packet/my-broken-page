using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Dal.Repositories;

namespace MyBrokenPage.Dal.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyBrokenPageDal(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyBrokenPageContext>(context => context.UseSqlServer(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISecurityQuestionRepository, SecurityQuestionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserSecurityAnswerRepository, UserSecurityAnswerRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
