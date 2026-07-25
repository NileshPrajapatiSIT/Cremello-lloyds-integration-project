using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.Chaps;

/// <summary>Maps to RequestDataWrapperOfPaymentInitiation in bilateral-chaps-payment-channel-api-v4.0.0.yaml.</summary>
public class RequestDataWrapperOfPaymentInitiation
{
    [JsonPropertyName("initiation")]
    public PaymentInitiation Initiation { get; set; } = new();
}
