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
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
        }
    }
}
