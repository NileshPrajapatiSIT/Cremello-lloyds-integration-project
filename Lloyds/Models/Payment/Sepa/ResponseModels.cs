using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Sepa;

/// <summary>Explains an ISO reason code affecting the payment status.</summary>
public class StatusReasonInformation
{
    [JsonPropertyName("additionalInformation")]
    public List<string>? AdditionalInformation { get; set; }

    [JsonPropertyName("isoReasonCode")]
    public string? IsoReasonCode { get; set; }
}

/// <summary>Response payload data for the created (or rejected) payment order.</summary>
public class PaymentMethodResponseDataOfPaymentInitiation
{
    [JsonPropertyName("creationDateTime")]
    public string? CreationDateTime { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }

    [JsonPropertyName("initiation")]
    public PaymentInitiation Initiation { get; set; } = new();

    [JsonPropertyName("instructionIdentification")]
    public string InstructionIdentification { get; set; } = string.Empty;

    [JsonPropertyName("isoStatus")]
    public string IsoStatus { get; set; } = string.Empty;

    [JsonPropertyName("paymentOrderIdentification")]
    public string PaymentOrderIdentification { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("statusReasonInformation")]
    public List<StatusReasonInformation>? StatusReasonInformation { get; set; }

    [JsonPropertyName("statusUpdate")]
    public string? StatusUpdate { get; set; }
}

/// <summary>Top-level response body for POST /sepa-payments.</summary>
public class SepaPaymentResponse
{
    [JsonPropertyName("data")]
    public PaymentMethodResponseDataOfPaymentInitiation? Data { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }
}
