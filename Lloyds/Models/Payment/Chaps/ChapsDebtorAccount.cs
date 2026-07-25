using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Account to be debited. Maps to ChapsDebtorAccount in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class ChapsDebtorAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    /// <summary>SortCodeAccountNumber, IBAN, AgencyBankAccountNumber, Virtual or VirtualIBAN.</summary>
    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }

    [JsonPropertyName("legalEntityIdentifier")]
    public string? LegalEntityIdentifier { get; set; }
}
