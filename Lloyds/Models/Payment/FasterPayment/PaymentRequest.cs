using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Request body for POST /faster-payments. Maps to PaymentRequest in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class PaymentRequest
{
    [JsonPropertyName("data")]
    public RequestDataWrapperOfPaymentInitiation Data { get; set; } = new();
}
