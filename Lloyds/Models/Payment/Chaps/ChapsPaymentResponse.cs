using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Response body for POST /chaps-payments. Maps to ChapsPaymentResponse in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class ChapsPaymentResponse
{
    [JsonPropertyName("data")]
    public PaymentMethodResponseDataOfPaymentInitiation? Data { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }
}
