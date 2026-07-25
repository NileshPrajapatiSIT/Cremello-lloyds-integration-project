using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.AccountManagement;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements ICloseAccountService against bilateral-close-account-channel-api-v2.0.0.yaml.</summary>
public class CloseAccountService : ICloseAccountService
{
    private const string RequestUri = "/bilateral-close-account-api/v2/close-accounts";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public CloseAccountService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public async Task<LloydsApiResult<CloseAccountResponse>> CloseAccountAsync(
        CloseAccountRequest request,
        string? idempotencyKey = null,
        CancellationToken cancellationToken = default)
    {
        var headers = new Dictionary<string, string>
        {
            ["x-ibm-client-id"] = _settings.ApiKey,
            ["x-lbg-system-user-id"] = _settings.SystemUserId
        };

        if (!string.IsNullOrEmpty(idempotencyKey))
        {
            headers["x-idempotency-key"] = idempotencyKey;
        }

        return await _httpHelper.SendAsync<CloseAccountResponse>(
            HttpMethod.Post,
            RequestUri,
            request,
            headers,
            includeBearerToken: true,
            scope: _settings.PaymentScope,
            signRequest: true,
            cancellationToken: cancellationToken);
    }
}
