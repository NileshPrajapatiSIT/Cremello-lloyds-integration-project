using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using Lloyds.Configuration;
using Lloyds.Interfaces;
using Microsoft.Extensions.Options;

namespace Lloyds.Helpers;

/// <summary>
/// Implements IJwsSigner using the MLS certificate configured in LloydsSettings. Produces an RFC 7797 detached
/// RS256 JWS ("header..signature", payload omitted) following the convention documented for UK Open Banking /
/// FAPI-style detached signatures.
/// TODO: confirm the exact header claims Lloyds' gateway expects (e.g. whether additional claims such as
/// "http://openbanking.org.uk/iat" / "...iss" are required) against the Technical Implementation Guide's JWS
/// section once real certificates are available for end-to-end testing — this has not been verified against a
/// live Lloyds response.
/// </summary>
public class JwsSigner : IJwsSigner
{
    private readonly LloydsSettings _settings;

    public JwsSigner(IOptions<LloydsSettings> settings)
    {
        _settings = settings.Value;
    }

    public string? SignPayload(string jsonPayload)
    {
        using var certificate = CertificateHelper.TryLoad(_settings.MlsCertificatePath, _settings.MlsCertificatePassword);
        if (certificate is null)
        {
            return null;
        }

        using var rsa = certificate.GetRSAPrivateKey()
            ?? throw new InvalidOperationException("The configured MLS certificate does not contain an RSA private key.");

        var header = new Dictionary<string, object?>
        {
            ["alg"] = "RS256",
            ["kid"] = _settings.MlsKeyId,
            ["b64"] = false,
            ["crit"] = new[] { "b64" }
        };

        var encodedHeader = Base64UrlEncode(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(header)));

        // Detached signature per RFC 7797: signing input is base64url(header) + "." + raw (unencoded) payload.
        var signingInput = Encoding.UTF8.GetBytes($"{encodedHeader}.{jsonPayload}");
        var signature = rsa.SignData(signingInput, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        return $"{encodedHeader}..{Base64UrlEncode(signature)}";
    }

    private static string Base64UrlEncode(byte[] bytes) =>
        Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
}
