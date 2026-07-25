using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Payment.Sepa;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements ISepaPaymentService against bilateral-sepa-payment-channel-api-v2.0.0.yaml (basePath /bilateral-sepa-payment-api/v2).</summary>
public class SepaPaymentService : ISepaPaymentService
{
    private const string RequestUri = "/bilateral-sepa-payment-api/v2/sepa-payments";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public SepaPaymentService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public async Task<LloydsApiResult<SepaPaymentResponse>> InitiateSepaPaymentAsync(
        PaymentRequest request,
        CancellationToken cancellationToken = default)
    {
        // TODO: x-ibm-client-id is not explicitly listed as a parameter for this operation in the YAML (only
        // authorization, x-jws-signature and x-lbg-system-user-id are), but is sent defensively since Lloyds Gem
        // APIs are fronted by IBM API Connect, which typically requires it at the gateway/product level. Remove if
        // the gateway rejects it as unexpected.
        var headers = new Dictionary<string, string>
        {
            ["x-ibm-client-id"] = _settings.ApiKey,
            ["x-lbg-system-user-id"] = _settings.SystemUserId
        };

        return await _httpHelper.SendAsync<SepaPaymentResponse>(
            HttpMethod.Post,
            RequestUri,
            request,
            headers,
            includeBearerToken: true,
            scope: _settings.PaymentScope,
            signRequest: true,
            cancellationToken);
    }
}
