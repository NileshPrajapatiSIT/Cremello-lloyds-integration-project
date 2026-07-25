using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Additional information about an error. Maps to AdditionalInfo in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class AdditionalInfo
{
    [JsonPropertyName("fieldName")]
    public string? FieldName { get; set; }

    [JsonPropertyName("fieldValue")]
    public string? FieldValue { get; set; }

    [JsonPropertyName("narrative")]
    public string Narrative { get; set; } = string.Empty;
}
