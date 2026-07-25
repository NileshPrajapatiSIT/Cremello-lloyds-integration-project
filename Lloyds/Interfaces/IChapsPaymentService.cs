using Lloyds.Models;
using Lloyds.Models.Payment.Chaps;

namespace Lloyds.Interfaces;

/// <summary>Proxies the Bilateral Chaps Payment Initiation API (bilateral-chaps-payment-channel-api-v4.0.0.yaml).</summary>
public interface IChapsPaymentService
{
    /// <summary>POST /bilateral-chaps-payment-api/v4/chaps-payments — initiates a CHAPS payment.</summary>
    Task<LloydsApiResult<ChapsPaymentResponse>> InitiateChapsPaymentAsync(
        PaymentRequest request,
        CancellationToken cancellationToken = default);
}
