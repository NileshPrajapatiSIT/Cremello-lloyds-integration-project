using Lloyds.Models;

namespace Lloyds.Interfaces;

/// <summary>Thin wrapper around IHttpClientFactory used by every Lloyds *Service to call the bank's APIs.</summary>
public interface IHttpHelper
{
    /// <summary>
    /// Sends a JSON request. <paramref name="requestUri"/> is relative to LloydsSettings.BaseUrl.
    /// <paramref name="scope"/> is the OAuth scope to request/cache a bearer token for (ignored when
    /// <paramref name="includeBearerToken"/> is false) — pass LloydsSettings.ReportingScope or
    /// LloydsSettings.PaymentScope depending on the API being called.
    /// <paramref name="signRequest"/> adds an x-jws-signature header (detached JWS over the serialized body,
    /// via IJwsSigner) when true, as required on Payment Initiation and Account Management calls.
    /// </summary>
    Task<LloydsApiResult<TResponse>> SendAsync<TResponse>(
        HttpMethod method,
        string requestUri,
        object? body = null,
        IDictionary<string, string>? headers = null,
        bool includeBearerToken = true,
        string scope = "",
        bool signRequest = false,
        CancellationToken cancellationToken = default);
}
