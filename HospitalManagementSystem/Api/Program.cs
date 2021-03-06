using Domain.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Data;
using Service;
using Service.Constants;
using Service.Mapping;
using Service.Seeds;
using Swashbuckle.AspNetCore.Filters;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSession(option =>
//{
//    option.IdleTimeout = TimeSpan.FromHours(12);
//});

#region Add Controlllers

builder.Services.AddControllers()
    .AddFluentValidation()
    .AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


#endregion

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();

#region Configure IdentityOptions

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;

    options.User.RequireUniqueEmail = true;

    //options.Lockout.MaxFailedAccessAttempts = 5;
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    options.Lockout.AllowedForNewUsers = true;
});

#endregion

#region AddAuthentication

builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
               .AddJwtBearer(cfg =>
               {
                   cfg.RequireHttpsMetadata = false;
                   cfg.SaveToken = true;
                   cfg.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidIssuer = builder.Configuration["Jwt:Issuer"],
                       ValidAudience = builder.Configuration["Jwt:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                       ClockSkew = TimeSpan.Zero
                   };
               });

#endregion

#region AddAuthorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyTypes.Patients.Create, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Patients.Create); });
    options.AddPolicy(PolicyTypes.Patients.View, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Patients.View); });
    options.AddPolicy(PolicyTypes.Patients.Edit, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Patients.Edit); });
    options.AddPolicy(PolicyTypes.Patients.Delete, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Patients.Delete); });

    options.AddPolicy(PolicyTypes.Doctors.Create, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Doctors.Create); });
    options.AddPolicy(PolicyTypes.Doctors.View, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Doctors.View); });
    options.AddPolicy(PolicyTypes.Doctors.Edit, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Doctors.Edit); });
    options.AddPolicy(PolicyTypes.Doctors.Delete, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Doctors.Delete); });

    options.AddPolicy(PolicyTypes.Nurses.Create, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Nurses.Create); });
    options.AddPolicy(PolicyTypes.Nurses.View, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Nurses.View); });
    options.AddPolicy(PolicyTypes.Nurses.Edit, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Nurses.Edit); });
    options.AddPolicy(PolicyTypes.Nurses.Delete, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Nurses.Delete); });

    options.AddPolicy(PolicyTypes.Receptionists.Create, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Receptionists.Create); });
    options.AddPolicy(PolicyTypes.Receptionists.View, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Receptionists.View); });
    options.AddPolicy(PolicyTypes.Receptionists.Edit, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Receptionists.Edit); });
    options.AddPolicy(PolicyTypes.Receptionists.Delete, policy => { policy.RequireClaim(CustomClaimTypes.Permission, PolicyTypes.Receptionists.Delete); });
});

#endregion

#region Connection String  
builder.Services.AddSqlServer<AppDbContext>(
                    builder.Configuration.GetConnectionString("DefaultConnection"));
#endregion

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddHttpContextAccessor();

builder.Services.AddRepositories();

builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT_ApiIdentity", Version = "v1" });
//});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

#region Create Default Roles And User On Start Up

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("app");
    try
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);
        logger.LogInformation("Finished Seeding Default Data");
        logger.LogInformation("Application Starting");
    }
    catch (Exception ex)
    {
        logger.LogWarning(ex, "An error occurred seeding the DB");
    }
}

#endregion

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT_ApiIdentity v1"));
}

//Reference : Rovshen Quliyev

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

//app.UseSession();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
