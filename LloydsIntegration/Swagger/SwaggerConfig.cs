using Microsoft.OpenApi.Models;

namespace LloydsIntegration.Swagger;

/// <summary>Configures Swagger/OpenAPI generation, including the JWT bearer auth scheme shown in Swagger UI.</summary>
public static class SwaggerConfig
{
    public static void AddConfiguredSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Lloyds Integration API",
                Version = "v1",
                Description = "Internal API exposing Lloyds Bank Gem bilateral channel endpoints."
            });

            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter the JWT token obtained from /api/auth/login.",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            options.AddSecurityDefinition("Bearer", securityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securityScheme, Array.Empty<string>() }
            });

            // Several modules independently define same-named model classes (e.g. RequestDataWrapper, GatewayError)
            // in different namespaces; use the full type name to keep schema IDs unique.
            options.CustomSchemaIds(type => type.FullName);
        });
    }
}
