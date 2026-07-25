using Lloyds.Interfaces;
using Lloyds.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lloyds.Extensions;

public static class ReportingModuleBServiceCollectionExtensions
{
    public static IServiceCollection AddReportingModuleB(this IServiceCollection services)
    {
        services.AddScoped<IStatementService, StatementService>();
        services.AddScoped<IStatementRetrieveService, StatementRetrieveService>();
        services.AddScoped<ITransactionsService, TransactionsService>();
        return services;
    }
}
