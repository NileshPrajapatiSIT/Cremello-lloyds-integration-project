using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.PaymentStatus;

/// <summary>Maps to StatusReasonInformation in bilateral-payment-status-channel-api-v3.0.0.yaml.</summary>
public class StatusReasonInformation
{
    [JsonPropertyName("additionalInformation")]
    public List<string>? AdditionalInformation { get; set; }

    [JsonPropertyName("isoReasonCode")]
    public string? IsoReasonCode { get; set; }
}
