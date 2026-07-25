using Lloyds.Interfaces;
using Lloyds.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lloyds.Extensions;

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
