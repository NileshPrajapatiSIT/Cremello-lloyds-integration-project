using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Balance;

/// <summary>Maps to YAML definition 'Servicer'.</summary>
public class Servicer
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

/// <summary>Maps to YAML definition 'Amount'.</summary>
public class Amount
{
    [JsonPropertyName("amount")]
    public string? Value { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}

/// <summary>Maps to YAML definition 'CommonAccount'.</summary>
public class CommonAccount
{
    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to YAML definition 'CreditLine'.</summary>
public class CreditLine
{
    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    [JsonPropertyName("included")]
    public bool? Included { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
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
