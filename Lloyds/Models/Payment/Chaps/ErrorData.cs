using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Error detail. Maps to ErrorData in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
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
