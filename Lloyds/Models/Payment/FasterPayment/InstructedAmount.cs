using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Currency and amount of the payment instruction. Maps to InstructedAmount in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class InstructedAmount
{
    /// <summary>Pattern: ^\d{1,12}\.\d{2}$</summary>
    [JsonPropertyName("amount")]
    public string Amount { get; set; } = string.Empty;

    /// <summary>Must always be "GBP" for Faster Payments.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
}
