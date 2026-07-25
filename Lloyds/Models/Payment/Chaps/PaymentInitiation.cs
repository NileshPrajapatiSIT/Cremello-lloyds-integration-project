using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Requests movement of funds from the debtor account to a creditor for a single CHAPS payment. Maps to PaymentInitiation in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class PaymentInitiation
{
    [JsonPropertyName("creditorAccount")]
    public CreditorAccount CreditorAccount { get; set; } = new();

    [JsonPropertyName("creditorPostalAddress")]
    public CreditorPostalAddress? CreditorPostalAddress { get; set; }

    [JsonPropertyName("debtor")]
    public Debtor? Debtor { get; set; }

    [JsonPropertyName("debtorAccount")]
    public ChapsDebtorAccount DebtorAccount { get; set; } = new();

    [JsonPropertyName("debtorAgent")]
    public DebtorAgent? DebtorAgent { get; set; }

    [JsonPropertyName("debtorAgentAccount")]
    public DebtorAgentAccount? DebtorAgentAccount { get; set; }

    [JsonPropertyName("endtoEndIdentification")]
    public string EndtoEndIdentification { get; set; } = string.Empty;

    [JsonPropertyName("paymentPurposeCode")]
    public string? PaymentPurposeCode { get; set; }

    [JsonPropertyName("instructedAmount")]
    public InstructedAmount InstructedAmount { get; set; } = new();

    [JsonPropertyName("instructionIdentification")]
    public string InstructionIdentification { get; set; } = string.Empty;

    [JsonPropertyName("remittanceInformation")]
    public RemittanceInformation? RemittanceInformation { get; set; }

    /// <summary>ISO date format YYYY-MM-DD, must not be earlier than today.</summary>
    [JsonPropertyName("requestedExecutionDate")]
    public string RequestedExecutionDate { get; set; } = string.Empty;

    [JsonPropertyName("ultimateDebtor")]
    public UltimateDebtor? UltimateDebtor { get; set; }
}
