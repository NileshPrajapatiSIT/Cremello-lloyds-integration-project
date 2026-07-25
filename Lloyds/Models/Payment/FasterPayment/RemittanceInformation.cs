using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Maps to RemittanceInformation in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class RemittanceInformation
{
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("unstructured")]
    public string? Unstructured { get; set; }
}
