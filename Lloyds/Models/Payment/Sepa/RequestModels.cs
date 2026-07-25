using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Sepa;

/// <summary>Account to be credited. Must be an IBAN for SEPA payments.</summary>
public class CreditorAccount
{
    [JsonPropertyName("identification")]
    public string Identification { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>Must be "IBAN".</summary>
    [JsonPropertyName("schemeName")]
    public string SchemeName { get; set; } = string.Empty;
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

/// <summary>Account to be debited.</summary>
public class DebtorAccount
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

/// <summary>Fixed payment amount. Currency must always be "EUR" for SEPA Credit Transfer.</summary>
public class InstructedAmount
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
}

/// <summary>Matching/reconciliation information carried with the payment. Either Reference or Unstructured may be used, not both.</summary>
public class RemittanceInformation
{
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("unstructured")]
    public string? Unstructured { get; set; }
}

/// <summary>Financial institution servicing the creditor's account.</summary>
public class SepaCreditorAgent
{
    [JsonPropertyName("bankOrBusinessIdentificationCode")]
    public string? BankOrBusinessIdentificationCode { get; set; }
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
}

/// <summary>The SEPA Credit Transfer instruction sent to Lloyds.</summary>
public class PaymentInitiation
{
    [JsonPropertyName("categoryPurposeCode")]
    public string? CategoryPurposeCode { get; set; }

    [JsonPropertyName("creditorAccount")]
    public CreditorAccount CreditorAccount { get; set; } = new();

    [JsonPropertyName("creditorAgent")]
    public SepaCreditorAgent? CreditorAgent { get; set; }

    [JsonPropertyName("creditorPostalAddress")]
    public CreditorPostalAddress? CreditorPostalAddress { get; set; }

    [JsonPropertyName("debtorAccount")]
    public DebtorAccount DebtorAccount { get; set; } = new();

    [JsonPropertyName("endtoEndIdentification")]
    public string EndtoEndIdentification { get; set; } = string.Empty;

    [JsonPropertyName("exchangeRateInformation")]
    public ExchangeRateInformation? ExchangeRateInformation { get; set; }

    [JsonPropertyName("instructedAmount")]
    public InstructedAmount InstructedAmount { get; set; } = new();

    [JsonPropertyName("instructionIdentification")]
    public string InstructionIdentification { get; set; } = string.Empty;

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

/// <summary>Top-level request body for POST /sepa-payments.</summary>
public class PaymentRequest
{
    [JsonPropertyName("data")]
    public RequestDataWrapperOfPaymentInitiation Data { get; set; } = new();
}
