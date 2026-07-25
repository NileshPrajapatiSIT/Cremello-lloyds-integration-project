using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Maps to StatusReasonInformation in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class StatusReasonInformation
{
    [JsonPropertyName("additionalInformation")]
    public List<string>? AdditionalInformation { get; set; }

    [JsonPropertyName("isoReasonCode")]
    public string? IsoReasonCode { get; set; }
}
