using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Account to be credited. Maps to CreditorAccount in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class CreditorAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("legalEntityIdentifier")]
    public string? LegalEntityIdentifier { get; set; }

    /// <summary>"SortCodeAccountNumber" or "IBAN".</summary>
    [JsonPropertyName("schemeName")]
    public string SchemeName { get; set; } = string.Empty;

    [JsonPropertyName("secondaryIdentification")]
    public string? SecondaryIdentification { get; set; }
}
