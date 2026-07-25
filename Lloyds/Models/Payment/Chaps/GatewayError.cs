using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Maps to GatewayError (title: ErrorResponse) in bilateral-chaps-payment-channel-api-v4.0.0.yaml, returned for 401/404/405/406/429 responses.</summary>
public class GatewayError
{
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    // TODO: swagger declares "errors" as type:string with an ErrorData $ref under "items", which is malformed;
    // modeled as a list of ErrorData since that matches the evident intent.
    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }

    [JsonPropertyName("httpReason")]
    public string HttpReason { get; set; } = string.Empty;

    // Present in the yaml's example payloads but not declared under "properties" — kept for completeness.
    [JsonPropertyName("gtid")]
    public string? Gtid { get; set; }

    [JsonPropertyName("tid")]
    public string? Tid { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }
}
