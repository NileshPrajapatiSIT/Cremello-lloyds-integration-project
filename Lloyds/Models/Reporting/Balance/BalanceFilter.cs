using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Balance;

/// <summary>Maps to YAML definition 'BalanceFilter' — optional filters accepted in the body of POST /balances.</summary>
public class BalanceFilter
{
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

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("routingId")]
    public string? RoutingId { get; set; }

    [JsonPropertyName("servicerCountry")]
    public string? ServicerCountry { get; set; }

    [JsonPropertyName("servicerIdentification")]
    public string? ServicerIdentification { get; set; }

    [JsonPropertyName("virtualBalanceAccountId")]
    public string? VirtualBalanceAccountId { get; set; }

    [JsonPropertyName("virtualBalanceAccountName")]
    public string? VirtualBalanceAccountName { get; set; }

    [JsonPropertyName("virtualExternallyAddressable")]
    public bool? VirtualExternallyAddressable { get; set; }

    [JsonPropertyName("virtualHeaderAccountIdentification")]
    public string? VirtualHeaderAccountIdentification { get; set; }

    [JsonPropertyName("virtualHeaderAccountSchemeName")]
    public string? VirtualHeaderAccountSchemeName { get; set; }
}
