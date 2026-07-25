using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Account;

/// <summary>Maps to YAML definition 'Servicer'.</summary>
public class Servicer
{
    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to YAML definition 'ServicerDetails'.</summary>
public class ServicerDetails
{
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("routingId")]
    public string? RoutingId { get; set; }

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }

    [JsonPropertyName("senderBankAccountId")]
    public string? SenderBankAccountId { get; set; }

    [JsonPropertyName("senderBankIdentification")]
    public string? SenderBankIdentification { get; set; }
}

/// <summary>Maps to YAML definition 'HeaderAccount'.</summary>
public class HeaderAccount
{
    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to YAML definition 'Virtual' (renamed from 'Virtual' because that word is a C# keyword).</summary>
public class VirtualAccountInfo
{
    [JsonPropertyName("balanceAccountId")]
    public string? BalanceAccountId { get; set; }

    [JsonPropertyName("balanceAccountName")]
    public string? BalanceAccountName { get; set; }

    [JsonPropertyName("externallyAddressable")]
    public bool? ExternallyAddressable { get; set; }

    [JsonPropertyName("headerAccount")]
    public HeaderAccount? HeaderAccount { get; set; }
}

/// <summary>Maps to YAML definition 'OtherAccountIdentifiers'.</summary>
public class OtherAccountIdentifiers
{
    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }

    [JsonPropertyName("servicer")]
    public Servicer? Servicer { get; set; }
}

/// <summary>Maps to YAML definition 'CommonAccount'.</summary>
public class CommonAccount
{
    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to YAML definition 'AdditionalInfo'.</summary>
public class AdditionalInfo
{
    [JsonPropertyName("fieldName")]
    public string? FieldName { get; set; }

    [JsonPropertyName("fieldValue")]
    public string? FieldValue { get; set; }

    [JsonPropertyName("narrative")]
    public string? Narrative { get; set; }
}

/// <summary>Maps to YAML definition 'ErrorData'.</summary>
public class ErrorData
{
    [JsonPropertyName("account")]
    public CommonAccount? Account { get; set; }

    [JsonPropertyName("additionalInformation")]
    public AdditionalInfo? AdditionalInformation { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("reasonCode")]
    public string? ReasonCode { get; set; }
}

/// <summary>Maps to YAML definition 'FilterParam' — echoes the filters applied to an unqualified accounts request.</summary>
public class FilterParam
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

    [JsonPropertyName("pg")]
    public string? Pg { get; set; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("routingId")]
    public string? RoutingId { get; set; }

    [JsonPropertyName("servicerCountry")]
    public string? ServicerCountry { get; set; }

    [JsonPropertyName("servicerIdentification")]
    public string? ServicerIdentification { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("virtualAccountEligible")]
    public string? VirtualAccountEligible { get; set; }

    [JsonPropertyName("virtualAccountUsed")]
    public string? VirtualAccountUsed { get; set; }

    [JsonPropertyName("virtualBalanceAccountId")]
    public string? VirtualBalanceAccountId { get; set; }

    [JsonPropertyName("virtualBalanceAccountName")]
    public string? VirtualBalanceAccountName { get; set; }

    [JsonPropertyName("virtualExternallyAddressable")]
    public string? VirtualExternallyAddressable { get; set; }
}

/// <summary>Maps to YAML definition 'Links'.</summary>
public class Links
{
    [JsonPropertyName("next")]
    public string? Next { get; set; }

    [JsonPropertyName("prev")]
    public string? Prev { get; set; }

    [JsonPropertyName("self")]
    public string? Self { get; set; }
}

/// <summary>Maps to YAML definition 'Meta'.</summary>
public class Meta
{
    [JsonPropertyName("totalPages")]
    public long? TotalPages { get; set; }
}

/// <summary>Maps to YAML definition 'GatewayError' (schema title 'ErrorResponse'), returned on 401/404/405/406/429/503.</summary>
public class GatewayError
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    // TODO: YAML declares "errors" as type: string but also gives it an "items" ref to ErrorData,
    // which is inconsistent in the source spec. Modeled as an array here since that matches the apparent intent.
    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }

    [JsonPropertyName("httpReason")]
    public string? HttpReason { get; set; }
}
