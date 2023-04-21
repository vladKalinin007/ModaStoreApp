using Microsoft.OpenApi.Models;

namespace API.Extensions;

public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "Store API", Version = "v1" });

            var sercuritySchema = new OpenApiSecurityScheme()
            {
                Description = "JTW Auth Bearer Scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference()
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            };
            
            c.AddSecurityDefinition("Bearer", sercuritySchema);
            
            var securityRequirement = new OpenApiSecurityRequirement()
            {
                {sercuritySchema, new[] {"Bearer"}}
            };
            
            c.AddSecurityRequirement(securityRequirement);
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        
        app.UseSwaggerUI();

        return app;
    }
}