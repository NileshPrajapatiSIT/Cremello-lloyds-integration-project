using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Transactions;

// Models for bilateral-transactions-payment-channel-api-v5.0.0.yaml (basePath /bilateral-transaction-api/v5).
// Covers POST /transactions (transactionsUsingPOST).

/// <summary>Maps to definitions/AdditionalData.</summary>
public class TransactionAdditionalData
{
    [JsonPropertyName("adjustmentReason")]
    public string? AdjustmentReason { get; set; }

    [JsonPropertyName("adjustmentReasonName")]
    public string? AdjustmentReasonName { get; set; }

    [JsonPropertyName("itemStatus")]
    public string? ItemStatus { get; set; }

    [JsonPropertyName("itemStatusName")]
    public string? ItemStatusName { get; set; }

    [JsonPropertyName("itemType")]
    public string? ItemType { get; set; }

    [JsonPropertyName("itemTypeName")]
    public string? ItemTypeName { get; set; }

    [JsonPropertyName("postingText")]
    public string? PostingText { get; set; }

    [JsonPropertyName("prenoteIdentification")]
    public string? PrenoteIdentification { get; set; }

    [JsonPropertyName("referenceNumberOthers")]
    public string? ReferenceNumberOthers { get; set; }

    [JsonPropertyName("referenceNumberPayment")]
    public string? ReferenceNumberPayment { get; set; }

    [JsonPropertyName("returnReason")]
    public string? ReturnReason { get; set; }

    [JsonPropertyName("returnReasonName")]
    public string? ReturnReasonName { get; set; }

    [JsonPropertyName("reversalReason")]
    public string? ReversalReason { get; set; }

    [JsonPropertyName("reversalReasonName")]
    public string? ReversalReasonName { get; set; }

    [JsonPropertyName("transactionType")]
    public string? TransactionType { get; set; }

    [JsonPropertyName("transactionTypeName")]
    public string? TransactionTypeName { get; set; }

    [JsonPropertyName("transferReason")]
    public string? TransferReason { get; set; }

    [JsonPropertyName("transferReasonName")]
    public string? TransferReasonName { get; set; }
}

/// <summary>Maps to definitions/AdditionalInfo.</summary>
public class TransactionAdditionalInfo
{
    [JsonPropertyName("fieldName")]
    public string? FieldName { get; set; }

    [JsonPropertyName("fieldValue")]
    public string? FieldValue { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("narrative")]
    public string Narrative { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/Amount.</summary>
public class TransactionAmount
{
    /// <summary>Required.</summary>
    [JsonPropertyName("amount")]
    public string AmountValue { get; set; } = string.Empty;

    /// <summary>Required. ISO 4217 currency code.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/Balance.</summary>
public class TransactionBalance
{
    [JsonPropertyName("amount")]
    public TransactionAmount? Amount { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("creditDebitIndicator")]
    public string CreditDebitIndicator { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("creditDebitIndicatorCode")]
    public string CreditDebitIndicatorCode { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("typeCode")]
    public string TypeCode { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/BankTransactionCode.</summary>
public class TransactionBankTransactionCode
{
    [JsonPropertyName("domain")]
    public TransactionDomain? Domain { get; set; }
}

/// <summary>Maps to definitions/Domain.</summary>
public class TransactionDomain
{
    /// <summary>Required. ISO transaction domain code, e.g. ACMT.</summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("family")]
    public TransactionFamily? Family { get; set; }
}

/// <summary>Maps to definitions/Family.</summary>
public class TransactionFamily
{
    /// <summary>Required. ISO transaction family code within a domain.</summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    /// <summary>Required. ISO transaction sub-product family code.</summary>
    [JsonPropertyName("subCode")]
    public string SubCode { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/ChargeAmount.</summary>
public class TransactionChargeAmount
{
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}

/// <summary>Maps to definitions/CommonAccount. Used in ErrorData.account.</summary>
public class TransactionCommonAccount
{
    /// <summary>Required.</summary>
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    /// <summary>Enum: '', SortCodeAccountNumber, IBAN, ShadowIBAN, ShadowBBAN, Virtual, VirtualIBAN, VirtualExternal, VirtualExternalIBAN.</summary>
    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to definitions/CurrencyExchange.</summary>
public class TransactionCurrencyExchange
{
    [JsonPropertyName("contractIdentification")]
    public string? ContractIdentification { get; set; }

    [JsonPropertyName("exchangeRate")]
    public string? ExchangeRate { get; set; }

    [JsonPropertyName("instructedAmount")]
    public TransactionInstructedAmount? InstructedAmount { get; set; }

    [JsonPropertyName("quotationDate")]
    public string? QuotationDate { get; set; }

    [JsonPropertyName("sourceCurrency")]
    public string? SourceCurrency { get; set; }

    [JsonPropertyName("targetCurrency")]
    public string? TargetCurrency { get; set; }

    [JsonPropertyName("unitCurrency")]
    public string? UnitCurrency { get; set; }
}

/// <summary>Maps to definitions/InstructedAmount.</summary>
public class TransactionInstructedAmount
{
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}

/// <summary>Maps to definitions/DebtorAccount. Populated only for Inbound(1:1) payments (recipient items).</summary>
public class TransactionDebtorAccount
{
    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>Supported: SortCodeAccountNumber, IBAN.</summary>
    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to definitions/DebtorAgent. Populated only for Inbound(1:1) payments (recipient items).</summary>
public class TransactionDebtorAgent
{
    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>Always 'BICFI'.</summary>
    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to definitions/ErrorData.</summary>
public class TransactionErrorData
{
    [JsonPropertyName("account")]
    public TransactionCommonAccount? Account { get; set; }

    [JsonPropertyName("additionalInformation")]
    public TransactionAdditionalInfo? AdditionalInformation { get; set; }

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

/// <summary>Maps to definitions/Filter (request-side filter criteria).</summary>
public class TransactionFilter
{
    [JsonPropertyName("bankTransactionCode")]
    public string? BankTransactionCode { get; set; }

    [JsonPropertyName("bankTransactionSubCode")]
    public string? BankTransactionSubCode { get; set; }

    [JsonPropertyName("chequeNumber")]
    public string? ChequeNumber { get; set; }

    /// <summary>Enum: Credit, Debit.</summary>
    [JsonPropertyName("creditDebitIndicator")]
    public string? CreditDebitIndicator { get; set; }

    /// <summary>Enum: CRDT, DBIT.</summary>
    [JsonPropertyName("creditDebitIndicatorCode")]
    public string? CreditDebitIndicatorCode { get; set; }

    [JsonPropertyName("endtoEndIdentification")]
    public string? EndtoEndIdentification { get; set; }

    [JsonPropertyName("fromBookingDate")]
    public string? FromBookingDate { get; set; }

    [JsonPropertyName("fromInstructedAmount")]
    public string? FromInstructedAmount { get; set; }

    [JsonPropertyName("fromPostedAmount")]
    public string? FromPostedAmount { get; set; }

    [JsonPropertyName("fromValueDate")]
    public string? FromValueDate { get; set; }

    [JsonPropertyName("instructedAmount")]
    public string? InstructedAmount { get; set; }

    [JsonPropertyName("instructedCurrency")]
    public string? InstructedCurrency { get; set; }

    [JsonPropertyName("instructionIdentification")]
    public string? InstructionIdentification { get; set; }

    [JsonPropertyName("postedAmount")]
    public string? PostedAmount { get; set; }

    [JsonPropertyName("toBookingDate")]
    public string? ToBookingDate { get; set; }

    [JsonPropertyName("toInstructedAmount")]
    public string? ToInstructedAmount { get; set; }

    [JsonPropertyName("toPostedAmount")]
    public string? ToPostedAmount { get; set; }

    [JsonPropertyName("toValueDate")]
    public string? ToValueDate { get; set; }

    [JsonPropertyName("transactionReference")]
    public string? TransactionReference { get; set; }

    [JsonPropertyName("virtualAccountReference")]
    public string? VirtualAccountReference { get; set; }
}

/// <summary>Maps to definitions/Links.</summary>
public class TransactionLinks
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
public class TransactionMeta
{
    /// <summary>Required.</summary>
    [JsonPropertyName("totalPages")]
    public long TotalPages { get; set; }
}

/// <summary>Maps to definitions/References.</summary>
public class TransactionReferences
{
    [JsonPropertyName("chequeNumber")]
    public string? ChequeNumber { get; set; }

    [JsonPropertyName("clearingSystemReference")]
    public string? ClearingSystemReference { get; set; }

    [JsonPropertyName("endtoEndIdentification")]
    public string? EndtoEndIdentification { get; set; }

    [JsonPropertyName("instructionIdentification")]
    public string? InstructionIdentification { get; set; }

    [JsonPropertyName("mandateIdentification")]
    public string? MandateIdentification { get; set; }

    [JsonPropertyName("messageIdentification")]
    public string? MessageIdentification { get; set; }

    [JsonPropertyName("paymentInformationIdentification")]
    public string? PaymentInformationIdentification { get; set; }

    [JsonPropertyName("transactionIdentification")]
    public string? TransactionIdentification { get; set; }

    [JsonPropertyName("virtualAccountReference")]
    public string? VirtualAccountReference { get; set; }
}

/// <summary>Maps to definitions/TransactionAccount.</summary>
public class TransactionAccount
{
    /// <summary>Required.</summary>
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    /// <summary>Enum: '', SortCodeAccountNumber, IBAN, Virtual, VirtualIBAN, VirtualExternal, VirtualExternalIBAN.</summary>
    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Maps to definitions/RequestDataWrapper.</summary>
public class TransactionRequestDataWrapper
{
    /// <summary>Required. minItems: 1, maxItems: 1.</summary>
    [JsonPropertyName("account")]
    public List<TransactionAccount> Account { get; set; } = new();

    [JsonPropertyName("filter")]
    public TransactionFilter? Filter { get; set; }
}

/// <summary>Request body for POST /transactions. Maps to definitions/TransactionRequest.</summary>
public class TransactionRequest
{
    /// <summary>Required.</summary>
    [JsonPropertyName("data")]
    public TransactionRequestDataWrapper Data { get; set; } = new();
}

/// <summary>Maps to definitions/Transaction (a single transaction entry).</summary>
public class TransactionEntry
{
    [JsonPropertyName("account")]
    public TransactionAccount? Account { get; set; }

    [JsonPropertyName("additionalData")]
    public TransactionAdditionalData? AdditionalData { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("amount")]
    public TransactionAmount Amount { get; set; } = new();

    /// <summary>Required.</summary>
    [JsonPropertyName("balance")]
    public TransactionBalance Balance { get; set; } = new();

    /// <summary>Required.</summary>
    [JsonPropertyName("bankTransactionCode")]
    public TransactionBankTransactionCode BankTransactionCode { get; set; } = new();

    /// <summary>Required.</summary>
    [JsonPropertyName("bookingDateTime")]
    public string BookingDateTime { get; set; } = string.Empty;

    [JsonPropertyName("chargeAmount")]
    public TransactionChargeAmount? ChargeAmount { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("creationDateTime")]
    public string CreationDateTime { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("creditDebitIndicator")]
    public string CreditDebitIndicator { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("creditDebitIndicatorCode")]
    public string CreditDebitIndicatorCode { get; set; } = string.Empty;

    [JsonPropertyName("currencyExchange")]
    public TransactionCurrencyExchange? CurrencyExchange { get; set; }

    [JsonPropertyName("debtorAccount")]
    public TransactionDebtorAccount? DebtorAccount { get; set; }

    [JsonPropertyName("debtorAgent")]
    public TransactionDebtorAgent? DebtorAgent { get; set; }

    [JsonPropertyName("references")]
    public TransactionReferences? References { get; set; }

    [JsonPropertyName("reversalIndicator")]
    public bool? ReversalIndicator { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("statusCode")]
    public string StatusCode { get; set; } = string.Empty;

    [JsonPropertyName("transactionReference")]
    public string? TransactionReference { get; set; }

    [JsonPropertyName("valueDateTime")]
    public string? ValueDateTime { get; set; }
}

/// <summary>Maps to definitions/ResponseFilterParam (echoed filter criteria applied to the response).</summary>
public class TransactionResponseFilterParam
{
    [JsonPropertyName("bankTransactionCode")]
    public string? BankTransactionCode { get; set; }

    [JsonPropertyName("bankTransactionSubCode")]
    public string? BankTransactionSubCode { get; set; }

    [JsonPropertyName("chequeNumber")]
    public string? ChequeNumber { get; set; }

    [JsonPropertyName("creditDebitIndicator")]
    public string? CreditDebitIndicator { get; set; }

    [JsonPropertyName("creditDebitIndicatorCode")]
    public string? CreditDebitIndicatorCode { get; set; }

    [JsonPropertyName("endtoEndIdentification")]
    public string? EndtoEndIdentification { get; set; }

    [JsonPropertyName("fromBookingDate")]
    public string? FromBookingDate { get; set; }

    /// <summary>Default filter used to restrict number of records in case no filter is provided in the request.</summary>
    [JsonPropertyName("fromCreationDate")]
    public string? FromCreationDate { get; set; }

    [JsonPropertyName("fromInstructedAmount")]
    public string? FromInstructedAmount { get; set; }

    [JsonPropertyName("fromPostedAmount")]
    public string? FromPostedAmount { get; set; }

    [JsonPropertyName("fromValueDate")]
    public string? FromValueDate { get; set; }

    [JsonPropertyName("instructedAmount")]
    public string? InstructedAmount { get; set; }

    [JsonPropertyName("instructedCurrency")]
    public string? InstructedCurrency { get; set; }

    [JsonPropertyName("instructionIdentification")]
    public string? InstructionIdentification { get; set; }

    [JsonPropertyName("postedAmount")]
    public string? PostedAmount { get; set; }

    [JsonPropertyName("toBookingDate")]
    public string? ToBookingDate { get; set; }

    /// <summary>Default filter used to restrict number of records in case no filter is provided in the request.</summary>
    [JsonPropertyName("toCreationDate")]
    public string? ToCreationDate { get; set; }

    [JsonPropertyName("toInstructedAmount")]
    public string? ToInstructedAmount { get; set; }

    [JsonPropertyName("toPostedAmount")]
    public string? ToPostedAmount { get; set; }

    [JsonPropertyName("toValueDate")]
    public string? ToValueDate { get; set; }

    [JsonPropertyName("transactionReference")]
    public string? TransactionReference { get; set; }

    [JsonPropertyName("virtualAccountReference")]
    public string? VirtualAccountReference { get; set; }
}

/// <summary>Maps to definitions/ResponseDataWrapper.</summary>
public class TransactionResponseDataWrapper
{
    [JsonPropertyName("errors")]
    public List<TransactionErrorData>? Errors { get; set; }

    [JsonPropertyName("filter")]
    public TransactionResponseFilterParam? Filter { get; set; }

    [JsonPropertyName("transaction")]
    public List<TransactionEntry>? Transaction { get; set; }
}

/// <summary>Response body for POST /transactions. Maps to definitions/TransactionResponse.</summary>
public class TransactionResponse
{
    [JsonPropertyName("data")]
    public TransactionResponseDataWrapper? Data { get; set; }

    [JsonPropertyName("links")]
    public TransactionLinks? Links { get; set; }

    [JsonPropertyName("meta")]
    public TransactionMeta? Meta { get; set; }

    [JsonPropertyName("errors")]
    public List<TransactionErrorData>? Errors { get; set; }
}

/// <summary>Maps to definitions/GatewayError (title: ErrorResponse). Returned on 401/404/405/406/429/503.</summary>
public class TransactionGatewayError
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
