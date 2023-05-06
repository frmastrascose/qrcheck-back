using Microsoft.OpenApi.Models;

namespace Hackaton.Api.Configurations;

public static class SwaggerMiddleware

{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition("API_KEY", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Name = "API_KEY",
                Description = "Key authorization access Hackaton API"
            });

            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "API_KEY" }
                    },
                    new string[] { }
                }
            });
        });
    }
}
