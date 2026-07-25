using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Payment.Chaps;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements IChapsPaymentService against bilateral-chaps-payment-channel-api-v4.0.0.yaml (basePath /bilateral-chaps-payment-api/v4).</summary>
public class ChapsPaymentService : IChapsPaymentService
{
    private const string ChapsPaymentsUri = "/bilateral-chaps-payment-api/v4/chaps-payments";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public ChapsPaymentService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public Task<LloydsApiResult<ChapsPaymentResponse>> InitiateChapsPaymentAsync(
        PaymentRequest request,
        CancellationToken cancellationToken = default)
    {
        var headers = new Dictionary<string, string>
        {
            ["x-lbg-system-user-id"] = _settings.SystemUserId
        };

        return _httpHelper.SendAsync<ChapsPaymentResponse>(
            HttpMethod.Post,
            ChapsPaymentsUri,
            request,
            headers,
            includeBearerToken: true,
            scope: _settings.PaymentScope,
            signRequest: true,
            cancellationToken);
    }
}
