using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Currency and amount of the payment instruction. Maps to InstructedAmount in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class InstructedAmount
{
    /// <summary>Pattern: ^\d{1,13}\.\d{2}$</summary>
    [JsonPropertyName("amount")]
    public string Amount { get; set; } = string.Empty;

    /// <summary>Must always be "GBP" for CHAPS.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
}
