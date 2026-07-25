namespace Lloyds.Interfaces;

/// <summary>Acquires and caches OAuth2 client-credentials access tokens for calling Lloyds Bank Gem APIs.
/// Tokens are cached per scope, since Reporting (commercial_account, ~90 day TTL) and Payment/Account
/// Management (commercial_payment, ~1 hour TTL) use different scopes with different lifetimes.</summary>
public interface ITokenHelper
{
    Task<string> GetAccessTokenAsync(string scope, CancellationToken cancellationToken = default);
}
