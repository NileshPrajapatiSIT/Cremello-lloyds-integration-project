using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Payment.PaymentStatus;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements IPaymentStatusService against bilateral-payment-status-channel-api-v3.0.0.yaml (basePath /bilateral-payment-status-api/v3).</summary>
public class PaymentStatusService : IPaymentStatusService
{
    private const string PaymentStatusUri = "/bilateral-payment-status-api/v3/payment-status";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public PaymentStatusService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public Task<LloydsApiResult<PaymentStatusResponse>> GetPaymentStatusAsync(
        string paymentOrderIdentification,
        CancellationToken cancellationToken = default)
    {
        var headers = new Dictionary<string, string>
        {
            ["x-lbg-system-user-id"] = _settings.SystemUserId
        };

        var requestUri = $"{PaymentStatusUri}?paymentOrderIdentification={Uri.EscapeDataString(paymentOrderIdentification)}";

        return _httpHelper.SendAsync<PaymentStatusResponse>(
            HttpMethod.Get,
            requestUri,
            null,
            headers,
            includeBearerToken: true,
            scope: _settings.PaymentScope,
            cancellationToken: cancellationToken);
    }
}
