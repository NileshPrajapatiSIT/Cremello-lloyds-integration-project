using Lloyds.Interfaces;
using Lloyds.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lloyds.Extensions;

/// <summary>Registers the Account Reporting and Balance proxy services.</summary>
public static class ReportingModuleAServiceCollectionExtensions
{
    public static IServiceCollection AddReportingModuleA(this IServiceCollection services)
    {
        services.AddScoped<IAccountReportingService, AccountReportingService>();
        services.AddScoped<IBalanceService, BalanceService>();
        return services;
    }
}
