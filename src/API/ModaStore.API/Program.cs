using System.Reflection;



using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModaStore.API.Extensions;
using ModaStore.API.Helpers;
using ModaStore.API.Middleware;
using ModaStore.Application.Extensions;
using ModaStore.Application.Mapping.Config;
using ModaStore.Application.Mapping.MappingProfiles;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces;
using ModaStore.Infrastructure.Data;
using ModaStore.Infrastructure.Extensions;
using ModaStore.Infrastructure.Identity;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

#region Services

builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddApplicationServices();
builder.Services.AddAPIServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
AutoMapperConfig.Initialize();


var app = builder.Build();

#endregion

#region Middleware

app.UseMiddleware<ExceptionMiddleware>();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }

    await next();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseSwaggerDocumentation();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("AllowAllOrigins");

app.UseAuthentication();

app.UseAuthorization();

#endregion

#region Routing

app.MapControllers();

#endregion

#region Endpoints

app.Run();

#endregion

