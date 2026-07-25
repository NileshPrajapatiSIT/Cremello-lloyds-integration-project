using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Payment.Transfer;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements ITransferService against bilateral-transfer-channel-api-v3.0.0.yaml (basePath /bilateral-transfer-api/v3).</summary>
public class TransferService : ITransferService
{
    private const string RequestUri = "/bilateral-transfer-api/v3/transfers";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public TransferService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public async Task<LloydsApiResult<TransferPaymentResponse>> InitiateTransferAsync(
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

        return await _httpHelper.SendAsync<TransferPaymentResponse>(
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
