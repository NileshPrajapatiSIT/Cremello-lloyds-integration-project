using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements ILloydsOAuthService against the LBG Group OAuth API described in lbg-group-oauth-api-1-3-0.yaml.</summary>
public class LloydsOAuthService : ILloydsOAuthService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly LloydsSettings _settings;
    private readonly ILogger<LloydsOAuthService> _logger;

    public LloydsOAuthService(IHttpClientFactory httpClientFactory, IOptions<LloydsSettings> settings, ILogger<LloydsOAuthService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _settings = settings.Value;
        _logger = logger;
    }

    public async Task<LloydsApiResult<AccessTokenResponse>> RequestTokenAsync(
        string grantType,
        string? clientId,
        string? clientSecret,
        string? scope,
        CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient("LloydsTokenClient");

        var form = new Dictionary<string, string>
        {
            ["grant_type"] = grantType,
            ["client_id"] = clientId ?? _settings.ClientId,
            ["client_secret"] = clientSecret ?? _settings.ClientSecret,
            ["scope"] = scope ?? _settings.Scope
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, _settings.TokenUrl)
        {
            Content = new FormUrlEncodedContent(form)
        };

        using var response = await client.SendAsync(request, cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning("Lloyds /token request failed with {StatusCode}: {Content}", (int)response.StatusCode, content);
            return LloydsApiResult<AccessTokenResponse>.Failure((int)response.StatusCode, response.ReasonPhrase ?? "Token request failed", content);
        }

        var data = System.Text.Json.JsonSerializer.Deserialize<AccessTokenResponse>(content, new System.Text.Json.JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return LloydsApiResult<AccessTokenResponse>.Success((int)response.StatusCode, data, content);
    }

    public string BuildAuthorizeUrl(string responseType, string clientId, string? scope, string? redirectUri, string? state)
    {
        var parameters = new List<string>
        {
            $"response_type={Uri.EscapeDataString(responseType)}",
            $"client_id={Uri.EscapeDataString(clientId)}"
        };
        if (!string.IsNullOrEmpty(scope)) parameters.Add($"scope={Uri.EscapeDataString(scope)}");
        if (!string.IsNullOrEmpty(redirectUri)) parameters.Add($"redirect_uri={Uri.EscapeDataString(redirectUri)}");
        if (!string.IsNullOrEmpty(state)) parameters.Add($"state={Uri.EscapeDataString(state)}");

        return $"{_settings.AuthorizeUrl}?{string.Join("&", parameters)}";
    }
}
