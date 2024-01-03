using Infrastructure.Interfaces;
using Infrastructure.Services;
using Repository.Interfaces;
using Repository.Repositories;

namespace API.Helpers
{
    public static class AppHelper
    {
        public static void InjectServices(IServiceCollection services) 
        {
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
