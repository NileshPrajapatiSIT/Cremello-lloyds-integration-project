using System.Text.Json;
using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Lloyds.Helpers;

/// <summary>
/// Requests and caches an OAuth2 client-credentials token from the Lloyds Group OAuth API
/// (POST {TokenUrl} per lbg-group-oauth-api-1-3-0.yaml) so every outbound Lloyds call can reuse it
/// until shortly before it expires.
/// </summary>
public class TokenHelper : ITokenHelper
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly LloydsSettings _settings;
    private readonly ILogger<TokenHelper> _logger;
    private readonly SemaphoreSlim _lock = new(1, 1);

    private readonly Dictionary<string, (string Token, DateTimeOffset ExpiresAt)> _cache = new();

    public TokenHelper(IHttpClientFactory httpClientFactory, IOptions<LloydsSettings> settings, ILogger<TokenHelper> logger)
    {
        _httpClientFactory = httpClientFactory;
        _settings = settings.Value;
        _logger = logger;
    }

    public async Task<string> GetAccessTokenAsync(string scope, CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue(scope, out var cached) && DateTimeOffset.UtcNow < cached.ExpiresAt)
        {
            return cached.Token;
        }

        await _lock.WaitAsync(cancellationToken);
        try
        {
            if (_cache.TryGetValue(scope, out cached) && DateTimeOffset.UtcNow < cached.ExpiresAt)
            {
                return cached.Token;
            }

            var client = _httpClientFactory.CreateClient("LloydsTokenClient");

            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials",
                ["client_id"] = _settings.ClientId,
                ["client_secret"] = _settings.ClientSecret,
                ["scope"] = scope
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, _settings.TokenUrl)
            {
                Content = new FormUrlEncodedContent(form)
            };

            using var response = await client.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Lloyds token request failed for scope '{Scope}' with status {StatusCode}: {Content}", scope, response.StatusCode, content);
                throw new InvalidOperationException($"Failed to obtain Lloyds access token for scope '{scope}' (status {(int)response.StatusCode}).");
            }

            var tokenResponse = JsonSerializer.Deserialize<AccessTokenResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (tokenResponse is null || string.IsNullOrEmpty(tokenResponse.AccessToken))
            {
                throw new InvalidOperationException($"Lloyds token response for scope '{scope}' did not contain an access_token.");
            }

            // Refresh a little early to avoid using a token that expires mid-flight.
            var safetyMarginSeconds = Math.Min(30, tokenResponse.ExpiresIn / 10 + 1);
            var expiresAt = DateTimeOffset.UtcNow.AddSeconds(tokenResponse.ExpiresIn - safetyMarginSeconds);
            _cache[scope] = (tokenResponse.AccessToken, expiresAt);

            return tokenResponse.AccessToken;
        }
        finally
        {
            _lock.Release();
        }
    }
}
