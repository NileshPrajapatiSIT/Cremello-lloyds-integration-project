using System.Text.Json.Serialization;

namespace Lloyds.Models.AccountManagement;

// Models for bilateral-create-account-channel-api-v2.0.0.yaml (operationId: createAccountsUsingPOST).

/// <summary>Request body. Maps to definitions/CreateAccountRequest.</summary>
public class CreateAccountRequest
{
    [JsonPropertyName("data")]
    public CreateAccountRequestData Data { get; set; } = new();
}

/// <summary>Maps to definitions/RequestDataWrapper.</summary>
public class CreateAccountRequestData
{
    [JsonPropertyName("account")]
    public List<CreateAccountItem> Account { get; set; } = new();
}

/// <summary>Maps to definitions/CreateAccount.</summary>
public class CreateAccountItem
{
    [JsonPropertyName("creditLineAmount")]
    public string? CreditLineAmount { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("openingDate")]
    public string? OpeningDate { get; set; }

    /// <summary>Required. Enum: VIRT_EXT, VIRT_INT.</summary>
    [JsonPropertyName("productId")]
    public string ProductId { get; set; } = string.Empty;

    [JsonPropertyName("referenceAccount")]
    public CreateAccountReferenceAccount? ReferenceAccount { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("virtual")]
    public CreateAccountVirtualRequest Virtual { get; set; } = new();
}

/// <summary>Maps to definitions/ReferenceAccount.</summary>
public class CreateAccountReferenceAccount
{
    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to definitions/VirtualRequest.</summary>
public class CreateAccountVirtualRequest
{
    [JsonPropertyName("accountReference")]
    public string? AccountReference { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("balanceAccountId")]
    public string BalanceAccountId { get; set; } = string.Empty;
}

/// <summary>Response body. Maps to definitions/CreateAccountResponse.</summary>
public class CreateAccountResponse
{
    [JsonPropertyName("data")]
    public CreateAccountResponseData? Data { get; set; }

    [JsonPropertyName("errors")]
    public List<CreateAccountErrorData>? Errors { get; set; }
}

/// <summary>Maps to definitions/CreateResponseDataWrapper.</summary>
public class CreateAccountResponseData
{
    [JsonPropertyName("account")]
    public List<CreateAccountAccountResponse>? Account { get; set; }
}

/// <summary>Maps to definitions/AccountResponse.</summary>
public class CreateAccountAccountResponse
{
    [JsonPropertyName("account")]
    public List<CreateAccountOtherIdentifier> Account { get; set; } = new();

    [JsonPropertyName("accountType")]
    public string AccountType { get; set; } = string.Empty;

    [JsonPropertyName("accountTypeCode")]
    public string AccountTypeCode { get; set; } = string.Empty;

    [JsonPropertyName("creditLine")]
    public List<CreateAccountCreditLine>? CreditLine { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonPropertyName("entityId")]
    public string EntityId { get; set; } = string.Empty;

    [JsonPropertyName("entityName")]
    public string EntityName { get; set; } = string.Empty;

    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("openingDate")]
    public string OpeningDate { get; set; } = string.Empty;

    [JsonPropertyName("productId")]
    public string ProductId { get; set; } = string.Empty;

    [JsonPropertyName("productName")]
    public string ProductName { get; set; } = string.Empty;

    [JsonPropertyName("referenceAccount")]
    public CreateAccountReferenceAccount? ReferenceAccount { get; set; }

    [JsonPropertyName("schemeName")]
    public string SchemeName { get; set; } = string.Empty;

    [JsonPropertyName("servicerDetails")]
    public CreateAccountServicerDetails ServicerDetails { get; set; } = new();

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("virtual")]
    public CreateAccountVirtual Virtual { get; set; } = new();
}

/// <summary>Maps to definitions/OtherAccountIdentifiers.</summary>
public class CreateAccountOtherIdentifier
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("schemeName")]
    public string SchemeName { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/CreditLine.</summary>
public class CreateAccountCreditLine
{
    [JsonPropertyName("amount")]
    public CreateAccountAmount? Amount { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/Amount.</summary>
public class CreateAccountAmount
{
    [JsonPropertyName("amount")]
    public string AmountValue { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/ServicerDetails.</summary>
public class CreateAccountServicerDetails
{
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; } = string.Empty;

    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("routingId")]
    public string RoutingId { get; set; } = string.Empty;

    [JsonPropertyName("schemeName")]
    public string SchemeName { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/Virtual.</summary>
public class CreateAccountVirtual
{
    [JsonPropertyName("accountReference")]
    public string? AccountReference { get; set; }

    [JsonPropertyName("balanceAccountId")]
    public string BalanceAccountId { get; set; } = string.Empty;

    [JsonPropertyName("balanceAccountName")]
    public string? BalanceAccountName { get; set; }

    [JsonPropertyName("externallyAddressable")]
    public bool? ExternallyAddressable { get; set; }

    [JsonPropertyName("headerAccount")]
    public CreateAccountHeaderAccount? HeaderAccount { get; set; }
}

/// <summary>Maps to definitions/HeaderAccount.</summary>
public class CreateAccountHeaderAccount
{
    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to definitions/ErrorData.</summary>
public class CreateAccountErrorData
{
    [JsonPropertyName("additionalInformation")]
    public CreateAccountAdditionalInfo? AdditionalInformation { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("reasonCode")]
    public string ReasonCode { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/AdditionalInfo.</summary>
public class CreateAccountAdditionalInfo
{
    [JsonPropertyName("fieldName")]
    public string? FieldName { get; set; }

    [JsonPropertyName("fieldValue")]
    public string? FieldValue { get; set; }

    [JsonPropertyName("narrative")]
    public string Narrative { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/GatewayError (title: ErrorResponse). Returned on 401/404/405/406/429/503.</summary>
public class CreateAccountGatewayError
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
