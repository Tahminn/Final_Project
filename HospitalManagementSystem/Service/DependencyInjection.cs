using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Service.Permission;
using Service.Services;
using Service.Services.AccountServices;
using Service.Services.Interfaces;
using Service.Services.PatientServices;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAppUserService, AppUserService>();

            services.AddScoped<IPatientService, PatientService>();

            services.AddTransient<ITokenService, TokenService>();

            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            return services;
        }
    }
}
