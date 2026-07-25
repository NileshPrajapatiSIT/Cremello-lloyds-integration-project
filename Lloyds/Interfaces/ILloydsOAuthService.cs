using Lloyds.Models;

namespace Lloyds.Interfaces;

/// <summary>Proxies the LBG Group OAuth API (lbg-group-oauth-api-1-3-0.yaml) on behalf of a caller-supplied client.</summary>
public interface ILloydsOAuthService
{
    /// <summary>POST /oauth2/v1/token — client credentials are those supplied by the caller (falls back to configured LloydsSettings if omitted).</summary>
    Task<LloydsApiResult<AccessTokenResponse>> RequestTokenAsync(
        string grantType,
        string? clientId,
        string? clientSecret,
        string? scope,
        CancellationToken cancellationToken = default);

    /// <summary>Builds the redirect URL for GET /oauth2/v1/authorize (Authorization Code / Implicit grants).</summary>
    string BuildAuthorizeUrl(string responseType, string clientId, string? scope, string? redirectUri, string? state);
}
