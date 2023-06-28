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

#region Services

builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddApplicationServices();
builder.Services.AddAPIServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
AutoMapperConfig.Initialize();


var app = builder.Build();

using (var scope = app.Services.CreateScope ())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    
    try
    {
        var context = services.GetRequiredService<StoreContext>();
        await context.Database.MigrateAsync();
        await StoreContextSeed.SeedAsync(context, loggerFactory);
        
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var identityContext = services.GetRequiredService<AppIdentityDbContext>();
        await identityContext.Database.MigrateAsync();
        await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occured during migrations");
    }
}

#endregion

#region Middleware

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

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

