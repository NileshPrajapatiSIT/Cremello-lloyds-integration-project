using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Lloyds.Interfaces;
using Lloyds.Models;
using Microsoft.Extensions.Logging;

namespace Lloyds.Helpers;

/// <summary>Sends requests to Lloyds Bank Gem APIs via the "LloydsClient" named HttpClient.</summary>
public class HttpHelper : IHttpHelper
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITokenHelper _tokenHelper;
    private readonly IJwsSigner _jwsSigner;
    private readonly ILogger<HttpHelper> _logger;

    public HttpHelper(IHttpClientFactory httpClientFactory, ITokenHelper tokenHelper, IJwsSigner jwsSigner, ILogger<HttpHelper> logger)
    {
        _httpClientFactory = httpClientFactory;
        _tokenHelper = tokenHelper;
        _jwsSigner = jwsSigner;
        _logger = logger;
    }

    public async Task<LloydsApiResult<TResponse>> SendAsync<TResponse>(
        HttpMethod method,
        string requestUri,
        object? body = null,
        IDictionary<string, string>? headers = null,
        bool includeBearerToken = true,
        string scope = "",
        bool signRequest = false,
        CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient("LloydsClient");
        using var request = new HttpRequestMessage(method, requestUri);

        string? json = null;
        if (body is not null)
        {
            json = JsonSerializer.Serialize(body, body.GetType());
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        if (includeBearerToken)
        {
            var token = await _tokenHelper.GetAccessTokenAsync(scope, cancellationToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        if (signRequest && json is not null)
        {
            var signature = _jwsSigner.SignPayload(json);
            if (signature is not null)
            {
                request.Headers.TryAddWithoutValidation("x-jws-signature", signature);
            }
            else
            {
                _logger.LogWarning("Skipping x-jws-signature on {Method} {Uri}: no MLS signing certificate configured (see Certificates/README.md).", method, requestUri);
            }
        }

        if (headers is not null)
        {
            foreach (var (key, value) in headers)
            {
                request.Headers.TryAddWithoutValidation(key, value);
            }
        }

        using var response = await client.SendAsync(request, cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning("Lloyds API call {Method} {Uri} returned {StatusCode}: {Content}", method, requestUri, (int)response.StatusCode, content);
            return LloydsApiResult<TResponse>.Failure((int)response.StatusCode, response.ReasonPhrase ?? "Request failed", content);
        }

        if (string.IsNullOrWhiteSpace(content))
        {
            return LloydsApiResult<TResponse>.Success((int)response.StatusCode, default, content);
        }

        try
        {
            var data = JsonSerializer.Deserialize<TResponse>(content, JsonOptions);
            return LloydsApiResult<TResponse>.Success((int)response.StatusCode, data, content);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to deserialize Lloyds API response for {Method} {Uri}", method, requestUri);
            return LloydsApiResult<TResponse>.Failure((int)response.StatusCode, "Failed to parse response from Lloyds API.", content);
        }
    }
}
