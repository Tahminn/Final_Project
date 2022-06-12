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

            services.AddScoped<IUserRepo, UserRepo>();

            services.AddScoped<IUserPatientRepo, UserPatientRepo>();

            services.AddScoped<IPatientRepo, PatientRepo>();

            services.AddScoped<ISettingRepo, SettingRepo>();

            services.AddScoped<IBedRepo, BedRepo>();
            
            services.AddScoped<IBirthRepo, BirthRepo>();
            
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            
            services.AddScoped<IGenderRepo, GenderRepo>();
            
            services.AddScoped<IOperationRepo, OperationRepo>();
            
            services.AddScoped<IPatientBillRepo, PatientBillRepo>();
            
            services.AddScoped<IPatientRepo, PatientRepo>();
            
            services.AddScoped<IPatientTestRepo, PatientTestRepo>();
            
            services.AddScoped<IPatientTriageRepo, PatientTriageRepo>();
            
            services.AddScoped<ITriageRepo, TriageRepo>();

            return services;
        }
    }
}
