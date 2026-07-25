using Lloyds.Interfaces;
using Lloyds.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lloyds.Extensions;

/// <summary>Registers the Statement, Statement Retrieve, and Transactions proxy services.</summary>
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
