using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Jwks;

// TODO: lbg-group-jwks-api-v1.0.0.yaml declares the 200 OK response with no body schema.
// Modeled here as a standard JWK Set (RFC 7517) — a "keys" array of key objects — since that is
// the conventional shape of a JWKS document; adjust if Lloyds' actual payload differs.
/// <summary>Response body for GET /lloydsbanking.jwks.</summary>
public class JwksResponse
{
    [JsonPropertyName("keys")]
    public List<Dictionary<string, object>>? Keys { get; set; }
}
