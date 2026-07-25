using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.PaymentStatus;

/// <summary>Additional information about an error. Maps to AdditionalInfo in bilateral-payment-status-channel-api-v3.0.0.yaml.</summary>
public class AdditionalInfo
{
    [JsonPropertyName("fieldName")]
    public string? FieldName { get; set; }

    [JsonPropertyName("fieldValue")]
    public string? FieldValue { get; set; }

    [JsonPropertyName("narrative")]
    public string Narrative { get; set; } = string.Empty;
}
