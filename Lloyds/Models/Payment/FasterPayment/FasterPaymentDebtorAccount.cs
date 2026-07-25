using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Account to be debited. Maps to FasterPaymentDebtorAccount in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class FasterPaymentDebtorAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    /// <summary>SortCodeAccountNumber, IBAN, AgencyBankAccountNumber, Virtual or VirtualIBAN.</summary>
    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}
