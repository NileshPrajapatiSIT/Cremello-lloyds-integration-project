using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Agency Bank only block identifying the client of the Agency Bank. Maps to Debtor in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class Debtor
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("postalAddress")]
    public PostalAddress? PostalAddress { get; set; }
}
