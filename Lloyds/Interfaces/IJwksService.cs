using Lloyds.Models;
using Lloyds.Models.Payment.Jwks;

namespace Lloyds.Interfaces;

/// <summary>Proxies the LBG Group domain JWKS API (lbg-group-jwks-api-v1.0.0.yaml).</summary>
public interface IJwksService
{
    /// <summary>GET /keystore/lloydsbanking.jwks — retrieves Lloyds Banking Group's public key set.</summary>
    Task<LloydsApiResult<JwksResponse>> GetJwksAsync(CancellationToken cancellationToken = default);
}
