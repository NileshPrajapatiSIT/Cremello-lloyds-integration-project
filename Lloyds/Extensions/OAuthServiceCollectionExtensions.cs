using Lloyds.Interfaces;
using Lloyds.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lloyds.Extensions;

/// <summary>Registers the Lloyds OAuth/Token proxy service.</summary>
public static class OAuthServiceCollectionExtensions
{
    public static IServiceCollection AddOAuthModule(this IServiceCollection services)
    {
        services.AddScoped<ILloydsOAuthService, LloydsOAuthService>();
        return services;
    }
}
