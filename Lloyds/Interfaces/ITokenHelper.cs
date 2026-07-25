namespace Lloyds.Interfaces;

/// <summary>Acquires and caches OAuth2 client-credentials access tokens for calling Lloyds Bank Gem APIs.
/// Tokens are cached per scope, since Reporting (commercial_account, ~90 day TTL) and Payment/Account
/// Management (commercial_payment, ~1 hour TTL) use different scopes with different lifetimes.</summary>
public interface ITokenHelper
{
    /// <summary>Returns a cached token for the given scope, requesting a fresh one from Lloyds' OAuth token
    /// endpoint if none is cached or the cached one is close to expiring.</summary>
    Task<string> GetAccessTokenAsync(string scope, CancellationToken cancellationToken = default);
}
