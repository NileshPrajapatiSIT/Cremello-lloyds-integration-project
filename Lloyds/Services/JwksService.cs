using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Payment.Jwks;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements IJwksService against lbg-group-jwks-api-v1.0.0.yaml (basePath /keystore). Uses apiKey auth (x-ibm-client-id), not OAuth.</summary>
public class JwksService : IJwksService
{
    private const string JwksUri = "/keystore/lloydsbanking.jwks";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public JwksService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public Task<LloydsApiResult<JwksResponse>> GetJwksAsync(CancellationToken cancellationToken = default)
    {
        var headers = new Dictionary<string, string>
        {
            ["x-ibm-client-id"] = _settings.ApiKey
        };

        return _httpHelper.SendAsync<JwksResponse>(
            HttpMethod.Get,
            JwksUri,
            null,
            headers,
            includeBearerToken: false,
            cancellationToken: cancellationToken);
    }
}
