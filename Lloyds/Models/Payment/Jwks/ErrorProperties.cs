using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Jwks;

// TODO: lbg-group-jwks-api-v1.0.0.yaml declares ErrorProperties as type:array while also listing
// object "properties" (code/reasonCode/message) — a malformed/self-contradictory schema.
// Modeled here as a plain object matching the declared properties, which is the evident intent.
/// <summary>Maps to ErrorProperties in lbg-group-jwks-api-v1.0.0.yaml.</summary>
public class ErrorProperties
{
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("reasonCode")]
    public string? ReasonCode { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}
