using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Transfer;

/// <summary>Account to be credited. Must be a Lloyds Bank Gem account.</summary>
public class CreditorAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>Must be "IBAN" or "SortCodeAccountNumber".</summary>
    [JsonPropertyName("schemeName")]
    public string SchemeName { get; set; } = string.Empty;
}

/// <summary>Account to be debited.</summary>
public class DebtorAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Fixed debit-side amount, used instead of InstructedAmount when the debit currency is to be fixed.</summary>
public class EquivalentAmount
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonPropertyName("currencyOfTransfer")]
    public string CurrencyOfTransfer { get; set; } = string.Empty;
}

/// <summary>Fixed transfer amount and currency.</summary>
public class InstructedAmount
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
}

/// <summary>Matching/reconciliation information carried with the transfer.</summary>
public class RemittanceInformation
{
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("unstructured")]
    public string? Unstructured { get; set; }
}

/// <summary>To be used for Lloyds Bank Virtual account payments (nEAVA credit reference).</summary>
public class UltimateCreditor
{
    [JsonPropertyName("otherOrganisationIdentification")]
    public string? OtherOrganisationIdentification { get; set; }
}

/// <summary>To be used for Lloyds Bank Virtual account payments (debtor-side virtual account reference).</summary>
public class UltimateDebtor
{
    [JsonPropertyName("otherOrganisationIdentification")]
    public string? OtherOrganisationIdentification { get; set; }
}

/// <summary>The internal Transfer instruction sent to Lloyds.</summary>
public class PaymentInitiation
{
    [JsonPropertyName("creditorAccount")]
    public CreditorAccount CreditorAccount { get; set; } = new();

    [JsonPropertyName("debtorAccount")]
    public DebtorAccount DebtorAccount { get; set; } = new();

    [JsonPropertyName("endtoEndIdentification")]
    public string EndtoEndIdentification { get; set; } = string.Empty;

    [JsonPropertyName("equivalentAmount")]
    public EquivalentAmount? EquivalentAmount { get; set; }

    [JsonPropertyName("instructedAmount")]
    public InstructedAmount? InstructedAmount { get; set; }

    [JsonPropertyName("instructionIdentification")]
    public string InstructionIdentification { get; set; } = string.Empty;

    [JsonPropertyName("remittanceInformation")]
    public RemittanceInformation? RemittanceInformation { get; set; }

    [JsonPropertyName("requestedExecutionDate")]
    public string RequestedExecutionDate { get; set; } = string.Empty;

    [JsonPropertyName("ultimateCreditor")]
    public UltimateCreditor? UltimateCreditor { get; set; }

    [JsonPropertyName("ultimateDebtor")]
    public UltimateDebtor? UltimateDebtor { get; set; }
}

/// <summary>Wrapper carrying the initiation payload under "data.initiation".</summary>
public class RequestDataWrapperOfPaymentInitiation
{
    [JsonPropertyName("initiation")]
    public PaymentInitiation Initiation { get; set; } = new();
}

/// <summary>Top-level request body for POST /transfers.</summary>
public class PaymentRequest
{
    [JsonPropertyName("data")]
    public RequestDataWrapperOfPaymentInitiation Data { get; set; } = new();
}
