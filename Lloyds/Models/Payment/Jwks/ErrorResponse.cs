using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Jwks;

/// <summary>Error body returned for 401/429/500 responses. Maps to ErrorResponse in lbg-group-jwks-api-v1.0.0.yaml.</summary>
public class ErrorResponse
{
    // TODO: swagger declares "error" as type:array of string while also $ref-ing ErrorProperties on the
    // same property, which is self-contradictory. Modeled as a list of ErrorProperties (the richer shape).
    [JsonPropertyName("error")]
    public List<ErrorProperties>? Error { get; set; }

    [JsonPropertyName("gtid")]
    public string? Gtid { get; set; }

    [JsonPropertyName("tid")]
    public string? Tid { get; set; }
}
