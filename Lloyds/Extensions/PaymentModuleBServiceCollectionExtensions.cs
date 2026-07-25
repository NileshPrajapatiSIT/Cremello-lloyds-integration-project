using Lloyds.Interfaces;
using Lloyds.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lloyds.Extensions;

/// <summary>Registers the International Payment, SEPA Payment and Transfer proxy services.</summary>
public static class PaymentModuleBServiceCollectionExtensions
{
    public static IServiceCollection AddPaymentModuleB(this IServiceCollection services)
    {
        services.AddScoped<IInternationalPaymentService, InternationalPaymentService>();
        services.AddScoped<ISepaPaymentService, SepaPaymentService>();
        services.AddScoped<ITransferService, TransferService>();
        return services;
    }
}
