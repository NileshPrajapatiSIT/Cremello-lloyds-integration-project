using Lloyds.Interfaces;
using Lloyds.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lloyds.Extensions;

/// <summary>Registers the Create Account and Close Account proxy services.</summary>
public static class AccountManagementServiceCollectionExtensions
{
    public static IServiceCollection AddAccountManagementModule(this IServiceCollection services)
    {
        services.AddScoped<ICreateAccountService, CreateAccountService>();
        services.AddScoped<ICloseAccountService, CloseAccountService>();
        return services;
    }
}
