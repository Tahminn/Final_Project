using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Repository.Repositories.PatientRepos;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepo<>), typeof(Repo<>));

            services.AddScoped<IPatientRepo, PatientRepo>();

            services.AddScoped<IAppUserRepo, AppUserRepo>();

            return services;
        }
    }
}
