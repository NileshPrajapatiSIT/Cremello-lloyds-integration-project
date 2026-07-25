using Lloyds.Interfaces;
using Lloyds.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lloyds.Extensions;

/// <summary>Registers the Chaps Payment, Faster Payment, Payment Status, and JWKS proxy services.</summary>
public static class PaymentModuleAServiceCollectionExtensions
{
    public static IServiceCollection AddPaymentModuleA(this IServiceCollection services)
    {
        services.AddScoped<IChapsPaymentService, ChapsPaymentService>();
        services.AddScoped<IFasterPaymentService, FasterPaymentService>();
        services.AddScoped<IPaymentStatusService, PaymentStatusService>();
        services.AddScoped<IJwksService, JwksService>();
        return services;
    }
}
