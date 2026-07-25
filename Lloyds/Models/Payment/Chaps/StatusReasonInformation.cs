using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Maps to StatusReasonInformation in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class StatusReasonInformation
{
    [JsonPropertyName("additionalInformation")]
    public List<string>? AdditionalInformation { get; set; }

    [JsonPropertyName("isoReasonCode")]
    public string? IsoReasonCode { get; set; }
}
