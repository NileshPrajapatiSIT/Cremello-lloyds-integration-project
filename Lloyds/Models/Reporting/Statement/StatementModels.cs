using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Statement;

// Models for bilateral-statement-channel-api-v4.0.0.yaml (basePath /bilateral-statement-api/v4).
// Covers GET /statements (unQualifiedStatementUsingGET) and POST /statements (qualifiedStatementsUsingPOST).

/// <summary>Maps to definitions/Account.</summary>
public class StatementAccount
{
    /// <summary>Required.</summary>
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    /// <summary>Enum: '', SortCodeAccountNumber, IBAN, ShadowIBAN, ShadowBBAN, Virtual, VirtualIBAN, VirtualExternal, VirtualExternalIBAN.</summary>
    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }

    /// <summary>Mandatory if schemeName is ShadowBBAN.</summary>
    [JsonPropertyName("servicer")]
    public StatementServicer? Servicer { get; set; }
}

/// <summary>Maps to definitions/Servicer.</summary>
public class StatementServicer
{
    /// <summary>Required. BIC value for the account.</summary>
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    /// <summary>Required. Always 'BICFI'.</summary>
    [JsonPropertyName("schemeName")]
    public string SchemeName { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/AdditionalInfo.</summary>
public class StatementAdditionalInfo
{
    [JsonPropertyName("fieldName")]
    public string? FieldName { get; set; }

    [JsonPropertyName("fieldValue")]
    public string? FieldValue { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("narrative")]
    public string Narrative { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/CommonAccount.</summary>
public class StatementCommonAccount
{
    /// <summary>Required.</summary>
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to definitions/ErrorData.</summary>
public class StatementErrorData
{
    [JsonPropertyName("account")]
    public StatementCommonAccount? Account { get; set; }

    [JsonPropertyName("additionalInformation")]
    public StatementAdditionalInfo? AdditionalInformation { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("reasonCode")]
    public string ReasonCode { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/Filter.</summary>
public class StatementFilter
{
    /// <summary>Enum: API, CBD, SWIFT-FIN.</summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; set; }

    /// <summary>Enum: MT940, MT942, MT950, CAMT.052, CAMT.053, LS01, BAI2.</summary>
    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("fromStatementDate")]
    public string? FromStatementDate { get; set; }

    [JsonPropertyName("toStatementDate")]
    public string? ToStatementDate { get; set; }
}

/// <summary>Maps to definitions/Links.</summary>
public class StatementLinks
{
    [JsonPropertyName("next")]
    public string? Next { get; set; }

    [JsonPropertyName("prev")]
    public string? Prev { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("self")]
    public string Self { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/Meta.</summary>
public class StatementMeta
{
    /// <summary>Required.</summary>
    [JsonPropertyName("totalPages")]
    public long TotalPages { get; set; }
}

/// <summary>Maps to definitions/QualifiedResponseDataWrapper.</summary>
public class StatementQualifiedResponseDataWrapper
{
    [JsonPropertyName("errors")]
    public List<StatementErrorData>? Errors { get; set; }

    [JsonPropertyName("filter")]
    public StatementFilter? Filter { get; set; }

    [JsonPropertyName("statement")]
    public List<StatementResponseAttributes>? Statement { get; set; }
}

/// <summary>Response body for POST /statements. Maps to definitions/QualifiedStatementResponse.</summary>
public class StatementQualifiedResponse
{
    [JsonPropertyName("data")]
    public StatementQualifiedResponseDataWrapper? Data { get; set; }

    [JsonPropertyName("links")]
    public StatementLinks? Links { get; set; }

    [JsonPropertyName("meta")]
    public StatementMeta? Meta { get; set; }

    [JsonPropertyName("errors")]
    public List<StatementErrorData>? Errors { get; set; }
}

/// <summary>Maps to definitions/RequestDataWrapper.</summary>
public class StatementRequestDataWrapper
{
    /// <summary>Required. Set of elements used to define the Statement details.</summary>
    [JsonPropertyName("account")]
    public List<StatementAccount> Account { get; set; } = new();

    [JsonPropertyName("filter")]
    public StatementFilter? Filter { get; set; }
}

/// <summary>Request body for POST /statements. Maps to definitions/StatementRequest.</summary>
public class StatementRequest
{
    /// <summary>Required.</summary>
    [JsonPropertyName("data")]
    public StatementRequestDataWrapper Data { get; set; } = new();
}

/// <summary>Maps to definitions/StatementResponseAttributes.</summary>
public class StatementResponseAttributes
{
    [JsonPropertyName("SequenceNumber")]
    public string? SequenceNumber { get; set; }

    [JsonPropertyName("StatementNumber")]
    public string? StatementNumber { get; set; }

    [JsonPropertyName("account")]
    public StatementAccount? Account { get; set; }

    /// <summary>Required. Enum: API, CBD, SWIFT-FIN.</summary>
    [JsonPropertyName("channel")]
    public string Channel { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("creationDateTime")]
    public string CreationDateTime { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("endDateTime")]
    public string EndDateTime { get; set; } = string.Empty;

    /// <summary>Required. Relative link to retrieve the statement file.</summary>
    [JsonPropertyName("fileRetrieve")]
    public string FileRetrieve { get; set; } = string.Empty;

    /// <summary>Required. Enum: MT940, MT942, MT950, CAMT.052, CAMT.053, LS01, BAI2.</summary>
    [JsonPropertyName("format")]
    public string Format { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("frequency")]
    public string Frequency { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("statementId")]
    public string StatementId { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/UnQualifiedResponseDataWrapper.</summary>
public class StatementUnQualifiedResponseDataWrapper
{
    [JsonPropertyName("errors")]
    public List<StatementErrorData>? Errors { get; set; }

    [JsonPropertyName("filter")]
    public StatementFilter? Filter { get; set; }

    [JsonPropertyName("statement")]
    public List<StatementResponseAttributes>? Statement { get; set; }
}

/// <summary>Response body for GET /statements. Maps to definitions/UnQualifiedStatementResponse.</summary>
public class StatementUnQualifiedResponse
{
    [JsonPropertyName("data")]
    public StatementUnQualifiedResponseDataWrapper? Data { get; set; }

    [JsonPropertyName("links")]
    public StatementLinks? Links { get; set; }

    [JsonPropertyName("meta")]
    public StatementMeta? Meta { get; set; }

    [JsonPropertyName("errors")]
    public List<StatementErrorData>? Errors { get; set; }
}

/// <summary>Maps to definitions/GatewayError (title: ErrorResponse). Returned on 401/404/405/406/429/503.</summary>
public class StatementGatewayError
{
    /// <summary>Required.</summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    // TODO: YAML declares "errors" as type: string but with "items" referencing ErrorData, which is
    // inconsistent in the spec (looks like it should be an array). Modeled as a nullable string per the
    // literal declared type.
    [JsonPropertyName("errors")]
    public string? Errors { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("httpReason")]
    public string HttpReason { get; set; } = string.Empty;
}
