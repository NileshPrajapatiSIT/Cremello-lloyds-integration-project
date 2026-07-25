using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Account;

/// <summary>Maps to YAML definition 'AccountResponseAttributes'.</summary>
public class AccountResponseAttributes
{
    [JsonPropertyName("account")]
    public List<OtherAccountIdentifiers>? Account { get; set; }

    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    [JsonPropertyName("accountTypeCode")]
    public string? AccountTypeCode { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("entityId")]
    public string? EntityId { get; set; }

    [JsonPropertyName("entityName")]
    public string? EntityName { get; set; }

    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("openingDate")]
    public string? OpeningDate { get; set; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }

    [JsonPropertyName("servicer")]
    public Servicer? Servicer { get; set; }

    [JsonPropertyName("servicerDetails")]
    public ServicerDetails? ServicerDetails { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("virtual")]
    public VirtualAccountInfo? Virtual { get; set; }

    [JsonPropertyName("virtualAccountEligible")]
    public bool? VirtualAccountEligible { get; set; }

    [JsonPropertyName("virtualAccountUsed")]
    public bool? VirtualAccountUsed { get; set; }
}
