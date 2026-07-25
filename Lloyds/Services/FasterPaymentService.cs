using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Payment.FasterPayment;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements IFasterPaymentService against bilateral-faster-payment-channel-api-v4.0.0.yaml (basePath /bilateral-faster-payment-api/v4).</summary>
public class FasterPaymentService : IFasterPaymentService
{
    private const string FasterPaymentsUri = "/bilateral-faster-payment-api/v4/faster-payments";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public FasterPaymentService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public Task<LloydsApiResult<FasterPaymentResponse>> InitiateFasterPaymentAsync(
        PaymentRequest request,
        CancellationToken cancellationToken = default)
    {
        var headers = new Dictionary<string, string>
        {
            ["x-lbg-system-user-id"] = _settings.SystemUserId
        };

        return _httpHelper.SendAsync<FasterPaymentResponse>(
            HttpMethod.Post,
            FasterPaymentsUri,
            request,
            headers,
            includeBearerToken: true,
            scope: _settings.PaymentScope,
            signRequest: true,
            cancellationToken);
    }
}
