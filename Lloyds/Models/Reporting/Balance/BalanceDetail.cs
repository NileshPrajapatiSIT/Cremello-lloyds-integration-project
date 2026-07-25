using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Balance;

/// <summary>Maps to YAML definition 'Balance' (renamed to avoid colliding with the containing namespace segment).</summary>
public class BalanceDetail
{
    [JsonPropertyName("account")]
    public AccountIdentifier? Account { get; set; }

    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    [JsonPropertyName("creditDebitIndicator")]
    public string? CreditDebitIndicator { get; set; }

    [JsonPropertyName("creditDebitIndicatorCode")]
    public string? CreditDebitIndicatorCode { get; set; }

    [JsonPropertyName("creditLine")]
    public List<CreditLine>? CreditLine { get; set; }

    [JsonPropertyName("dateTime")]
    public string? DateTime { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("typeCode")]
    public string? TypeCode { get; set; }
}
