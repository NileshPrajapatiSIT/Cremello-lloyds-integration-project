using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Maps to RequestDataWrapperOfPaymentInitiation in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class RequestDataWrapperOfPaymentInitiation
{
    [JsonPropertyName("initiation")]
    public PaymentInitiation Initiation { get; set; } = new();
}
