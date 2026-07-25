using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.PaymentStatus;

/// <summary>Maps to PaymentStatusResponseData in bilateral-payment-status-channel-api-v3.0.0.yaml.</summary>
public class PaymentStatusResponseData
{
    [JsonPropertyName("creationDateTime")]
    public string? CreationDateTime { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }

    [JsonPropertyName("expectedExecutionDate")]
    public string? ExpectedExecutionDate { get; set; }

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
