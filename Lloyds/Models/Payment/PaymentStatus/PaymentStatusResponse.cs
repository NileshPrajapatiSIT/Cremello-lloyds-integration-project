using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.PaymentStatus;

/// <summary>Response body for GET /payment-status. Maps to PaymentStatusResponse in bilateral-payment-status-channel-api-v3.0.0.yaml.</summary>
public class PaymentStatusResponse
{
    [JsonPropertyName("data")]
    public PaymentStatusResponseData? Data { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }
}
