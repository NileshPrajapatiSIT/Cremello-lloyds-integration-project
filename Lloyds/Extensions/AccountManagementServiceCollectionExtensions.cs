using Lloyds.Interfaces;
using Lloyds.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lloyds.Extensions;

public static class AccountManagementServiceCollectionExtensions
{
    public static IServiceCollection AddAccountManagementModule(this IServiceCollection services)
    {
        services.AddScoped<ICreateAccountService, CreateAccountService>();
        services.AddScoped<ICloseAccountService, CloseAccountService>();
        return services;
    }
}
