using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Transfer;

/// <summary>Additional information about a payment error.</summary>
public class AdditionalInfo
{
    [JsonPropertyName("fieldName")]
    public string? FieldName { get; set; }

    [JsonPropertyName("fieldValue")]
    public string? FieldValue { get; set; }

    [JsonPropertyName("narrative")]
    public string Narrative { get; set; } = string.Empty;
}

/// <summary>Error detail returned by the Transfer API.</summary>
public class ErrorData
{
    [JsonPropertyName("additionalInformation")]
    public AdditionalInfo? AdditionalInformation { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("reasonCode")]
    public string ReasonCode { get; set; } = string.Empty;
}

/// <summary>Gateway-level error response (schema title "ErrorResponse" in the YAML, definition key "GatewayError").</summary>
public class GatewayError
{
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    // TODO: YAML declares "errors" as type: string but nests an ErrorData "items" schema under it - the spec itself
    // is ambiguous/malformed here. Modeled as string to match the literally declared type.
    [JsonPropertyName("errors")]
    public string? Errors { get; set; }

    [JsonPropertyName("httpReason")]
    public string HttpReason { get; set; } = string.Empty;
}
