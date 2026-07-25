using System.Text.Json.Serialization;

namespace Lloyds.Models.AccountManagement;

// Models for bilateral-close-account-channel-api-v2.0.0.yaml (operationId: closeAccountsUsingPOST).

/// <summary>Request body. Maps to definitions/CloseAccountRequest.</summary>
public class CloseAccountRequest
{
    [JsonPropertyName("data")]
    public CloseAccountRequestData Data { get; set; } = new();
}

/// <summary>Maps to definitions/RequestDataWrapper.</summary>
public class CloseAccountRequestData
{
    [JsonPropertyName("account")]
    public List<CloseAccountItem> Account { get; set; } = new();
}

/// <summary>Maps to definitions/CloseAccount.</summary>
public class CloseAccountItem
{
    /// <summary>Required.</summary>
    [JsonPropertyName("closureSettlementAccount")]
    public CloseAccountClosureSettlementAccount ClosureSettlementAccount { get; set; } = new();

    [JsonPropertyName("executeSettlement")]
    public bool? ExecuteSettlement { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to definitions/ClosureSettlementAccount.</summary>
public class CloseAccountClosureSettlementAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("schemeName")]
    public string SchemeName { get; set; } = string.Empty;
}

/// <summary>Response body. Maps to definitions/CloseAccountResponse.</summary>
public class CloseAccountResponse
{
    [JsonPropertyName("data")]
    public CloseAccountResponseWrapper? Data { get; set; }

    [JsonPropertyName("errors")]
    public List<CloseAccountErrorData>? Errors { get; set; }
}

/// <summary>Maps to definitions/ResponseDataWrapper.</summary>
public class CloseAccountResponseWrapper
{
    [JsonPropertyName("account")]
    public List<CloseAccountResponseData>? Account { get; set; }
}

/// <summary>Maps to definitions/CloseAccountResponseData.</summary>
public class CloseAccountResponseData
{
    /// <summary>Enum: Virtual.</summary>
    [JsonPropertyName("accountType")]
    public string AccountType { get; set; } = string.Empty;

    /// <summary>Enum: VIRT.</summary>
    [JsonPropertyName("accountTypeCode")]
    public string AccountTypeCode { get; set; } = string.Empty;

    [JsonPropertyName("closureSettlementAccount")]
    public CloseAccountClosureSettlementAccount ClosureSettlementAccount { get; set; } = new();

    [JsonPropertyName("executeSettlement")]
    public bool ExecuteSettlement { get; set; }

    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("productId")]
    public string ProductId { get; set; } = string.Empty;

    [JsonPropertyName("productName")]
    public string ProductName { get; set; } = string.Empty;

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }

    /// <summary>Enum: Closed.</summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/ErrorData.</summary>
public class CloseAccountErrorData
{
    [JsonPropertyName("additionalInformation")]
    public CloseAccountAdditionalInfo? AdditionalInformation { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("reasonCode")]
    public string ReasonCode { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/AdditionalInfo.</summary>
public class CloseAccountAdditionalInfo
{
    [JsonPropertyName("fieldName")]
    public string? FieldName { get; set; }

    [JsonPropertyName("fieldValue")]
    public string? FieldValue { get; set; }

    [JsonPropertyName("narrative")]
    public string Narrative { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/GatewayError (title: ErrorResponse). Returned on 401/404/405/406/429/503.</summary>
public class CloseAccountGatewayError
{
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    // TODO: YAML declares "errors" as type: string but with "items" referencing ErrorData, which is
    // inconsistent in the spec (looks like it should be an array). Modeled as a nullable string per the
    // literal declared type.
    [JsonPropertyName("errors")]
    public string? Errors { get; set; }

    [JsonPropertyName("httpReason")]
    public string HttpReason { get; set; } = string.Empty;
}
