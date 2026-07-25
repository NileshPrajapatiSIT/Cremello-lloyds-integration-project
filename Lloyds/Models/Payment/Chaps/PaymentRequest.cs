using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Request body for POST /chaps-payments. Maps to PaymentRequest in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class PaymentRequest
{
    [JsonPropertyName("data")]
    public RequestDataWrapperOfPaymentInitiation Data { get; set; } = new();
}
