using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.AccountManagement;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements ICreateAccountService against bilateral-create-account-channel-api-v2.0.0.yaml.</summary>
public class CreateAccountService : ICreateAccountService
{
    private const string RequestUri = "/bilateral-create-account-api/v2/create-account";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public CreateAccountService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public async Task<LloydsApiResult<CreateAccountResponse>> CreateAccountAsync(
        CreateAccountRequest request,
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

        return await _httpHelper.SendAsync<CreateAccountResponse>(
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
