using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Response body for POST /faster-payments. Maps to FasterPaymentResponse in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class FasterPaymentResponse
{
    [JsonPropertyName("data")]
    public PaymentMethodResponseDataOfPaymentInitiation? Data { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }
}
