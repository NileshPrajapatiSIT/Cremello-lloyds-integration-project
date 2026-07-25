using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.International;

/// <summary>Account to be credited.</summary>
public class CreditorAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>Must be "BBAN" or "IBAN".</summary>
    [JsonPropertyName("schemeName")]
    public string SchemeName { get; set; } = string.Empty;
}

/// <summary>Financial institution servicing the creditor's account.</summary>
public class CreditorAgent
{
    [JsonPropertyName("bankOrBusinessIdentificationCode")]
    public string? BankOrBusinessIdentificationCode { get; set; }

    [JsonPropertyName("clearingSystemIdentificationCode")]
    public string? ClearingSystemIdentificationCode { get; set; }

    [JsonPropertyName("clearingSystemMemberIdentification")]
    public string? ClearingSystemMemberIdentification { get; set; }
}

/// <summary>Beneficiary postal address.</summary>
public class CreditorPostalAddress
{
    [JsonPropertyName("addressType")]
    public string? AddressType { get; set; }

    [JsonPropertyName("buildingNumber")]
    public string? BuildingNumber { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("countrySubDivision")]
    public string? CountrySubDivision { get; set; }

    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [JsonPropertyName("postCode")]
    public string? PostCode { get; set; }

    [JsonPropertyName("streetName")]
    public string? StreetName { get; set; }

    [JsonPropertyName("subDepartment")]
    public string? SubDepartment { get; set; }

    [JsonPropertyName("townName")]
    public string? TownName { get; set; }
}

/// <summary>Agency Bank-only block identifying the debtor's underlying client.</summary>
public class Debtor
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("postalAddress")]
    public PostalAddress? PostalAddress { get; set; }
}

/// <summary>Agency Bank-only: financial institution servicing the debtor's account.</summary>
public class DebtorAgent
{
    [JsonPropertyName("bankOrBusinessIdentificationCode")]
    public string? BankOrBusinessIdentificationCode { get; set; }

    [JsonPropertyName("clearingSystemIdentificationCode")]
    public string? ClearingSystemIdentificationCode { get; set; }

    [JsonPropertyName("clearingSystemMemberIdentification")]
    public string? ClearingSystemMemberIdentification { get; set; }
}

/// <summary>Agency Bank-only: the Agency Bank's own Lloyds account debited in settlement.</summary>
public class DebtorAgentAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Account to be debited.</summary>
public class InternationalDebtorAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}

/// <summary>Pre-agreed FX contract and rate.</summary>
public class ExchangeRateInformation
{
    [JsonPropertyName("contractIdentification")]
    public string ContractIdentification { get; set; } = string.Empty;

    [JsonPropertyName("exchangeRate")]
    public string ExchangeRate { get; set; } = string.Empty;
}

/// <summary>Fixed payment amount and currency.</summary>
public class InstructedAmount
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
}

/// <summary>Agent between the debtor's agent and the creditor's agent.</summary>
public class IntermediaryAgent
{
    [JsonPropertyName("bankOrBusinessIdentificationCode")]
    public string? BankOrBusinessIdentificationCode { get; set; }
}

/// <summary>Fixed debit-side amount, used instead of InstructedAmount when the debit currency is to be fixed.</summary>
public class InternationalEquivalentAmount
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonPropertyName("currencyOfTransfer")]
    public string CurrencyOfTransfer { get; set; } = string.Empty;
}

/// <summary>Structured postal address (used for Debtor / Ultimate Debtor blocks).</summary>
public class PostalAddress
{
    [JsonPropertyName("addressType")]
    public string? AddressType { get; set; }

    [JsonPropertyName("buildingNumber")]
    public string? BuildingNumber { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("countrySubDivision")]
    public string? CountrySubDivision { get; set; }

    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [JsonPropertyName("postCode")]
    public string? PostCode { get; set; }

    [JsonPropertyName("streetName")]
    public string? StreetName { get; set; }

    [JsonPropertyName("subDepartment")]
    public string? SubDepartment { get; set; }

    [JsonPropertyName("townName")]
    public string? TownName { get; set; }
}

/// <summary>Matching/reconciliation information carried with the payment.</summary>
public class RemittanceInformation
{
    [JsonPropertyName("unstructured")]
    public string? Unstructured { get; set; }
}

/// <summary>Ultimate party on whose behalf the payment is made (POBO / Virtual Account payments).</summary>
public class UltimateDebtor
{
    [JsonPropertyName("bankOrBusinessIdentificationCode")]
    public string? BankOrBusinessIdentificationCode { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("otherOrganisationIdentification")]
    public string? OtherOrganisationIdentification { get; set; }

    [JsonPropertyName("postalAddress")]
    public PostalAddress? PostalAddress { get; set; }
}

/// <summary>The payment instruction sent to Lloyds to move funds from debtor to creditor.</summary>
public class PaymentInitiation
{
    [JsonPropertyName("categoryPurposeCode")]
    public string? CategoryPurposeCode { get; set; }

    [JsonPropertyName("chargeBearer")]
    public string ChargeBearer { get; set; } = string.Empty;

    [JsonPropertyName("creditorAccount")]
    public CreditorAccount CreditorAccount { get; set; } = new();

    [JsonPropertyName("creditorAgent")]
    public CreditorAgent? CreditorAgent { get; set; }

    [JsonPropertyName("creditorPostalAddress")]
    public CreditorPostalAddress? CreditorPostalAddress { get; set; }

    [JsonPropertyName("debtor")]
    public Debtor? Debtor { get; set; }

    [JsonPropertyName("debtorAccount")]
    public InternationalDebtorAccount DebtorAccount { get; set; } = new();

    [JsonPropertyName("debtorAgent")]
    public DebtorAgent? DebtorAgent { get; set; }

    [JsonPropertyName("debtorAgentAccount")]
    public DebtorAgentAccount? DebtorAgentAccount { get; set; }

    [JsonPropertyName("endtoEndIdentification")]
    public string EndtoEndIdentification { get; set; } = string.Empty;

    [JsonPropertyName("equivalentAmount")]
    public InternationalEquivalentAmount? EquivalentAmount { get; set; }

    [JsonPropertyName("exchangeRateInformation")]
    public ExchangeRateInformation? ExchangeRateInformation { get; set; }

    [JsonPropertyName("instructedAmount")]
    public InstructedAmount? InstructedAmount { get; set; }

    [JsonPropertyName("instructionForCreditorAgentCode")]
    public string? InstructionForCreditorAgentCode { get; set; }

    [JsonPropertyName("instructionIdentification")]
    public string InstructionIdentification { get; set; } = string.Empty;

    [JsonPropertyName("intermediaryAgent")]
    public IntermediaryAgent? IntermediaryAgent { get; set; }

    [JsonPropertyName("paymentPurpose")]
    public string? PaymentPurpose { get; set; }

    [JsonPropertyName("remittanceInformation")]
    public RemittanceInformation? RemittanceInformation { get; set; }

    [JsonPropertyName("requestedExecutionDate")]
    public string RequestedExecutionDate { get; set; } = string.Empty;

    [JsonPropertyName("ultimateDebtor")]
    public UltimateDebtor? UltimateDebtor { get; set; }
}

/// <summary>Wrapper carrying the initiation payload under "data.initiation".</summary>
public class RequestDataWrapperOfPaymentInitiation
{
    [JsonPropertyName("initiation")]
    public PaymentInitiation Initiation { get; set; } = new();
}

/// <summary>Top-level request body for POST /international-payments.</summary>
public class PaymentRequest
{
    [JsonPropertyName("data")]
    public RequestDataWrapperOfPaymentInitiation Data { get; set; } = new();
}
