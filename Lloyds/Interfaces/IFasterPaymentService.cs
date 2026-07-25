using Lloyds.Models;
using Lloyds.Models.Payment.FasterPayment;

namespace Lloyds.Interfaces;

/// <summary>Proxies the Bilateral Faster Payment Initiation API (bilateral-faster-payment-channel-api-v4.0.0.yaml).</summary>
public interface IFasterPaymentService
{
    /// <summary>POST /bilateral-faster-payment-api/v4/faster-payments — initiates a Faster Payment.</summary>
    Task<LloydsApiResult<FasterPaymentResponse>> InitiateFasterPaymentAsync(
        PaymentRequest request,
        CancellationToken cancellationToken = default);
}
