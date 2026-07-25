using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Maps to RemittanceInformation in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class RemittanceInformation
{
    [JsonPropertyName("unstructured")]
    public string? Unstructured { get; set; }
}
