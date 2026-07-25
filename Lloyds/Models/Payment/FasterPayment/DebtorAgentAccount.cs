using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Agency Bank's account with Lloyds debited in settlement. Maps to DebtorAgentAccount in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class DebtorAgentAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    /// <summary>"IBAN" or "SortCodeAccountNumber".</summary>
    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}
