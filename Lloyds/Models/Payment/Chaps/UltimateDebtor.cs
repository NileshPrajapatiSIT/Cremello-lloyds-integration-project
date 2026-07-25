using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Ultimate party that owes the amount to the creditor (POBO / Virtual Account payments). Maps to UltimateDebtor in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class UltimateDebtor
{
    [JsonPropertyName("bankOrBusinessIdentificationCode")]
    public string? BankOrBusinessIdentificationCode { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("legalEntityIdentifier")]
    public string? LegalEntityIdentifier { get; set; }

    [JsonPropertyName("otherOrganisationIdentification")]
    public string? OtherOrganisationIdentification { get; set; }

    [JsonPropertyName("postalAddress")]
    public PostalAddress? PostalAddress { get; set; }
}
