using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Data;
using Service;
using Service.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation();

#region Connection String  
builder.Services.AddDbContext<AppDbContext>(options => options
                    .UseSqlServer(builder.Configuration
                    .GetConnectionString("DefaultConnection")));
#endregion

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddRepositories();

builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Reference : Rovshen Quliyev

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
