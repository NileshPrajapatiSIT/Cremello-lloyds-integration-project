using Lloyds.Models;
using Lloyds.Models.Payment.International;

namespace Lloyds.Interfaces;

/// <summary>Proxies the Bilateral International Payment Initiation API (bilateral-international-payment-channel-api-v3.0.0.yaml).</summary>
public interface IInternationalPaymentService
{
    /// <summary>POST /international-payments - initiate an International Payment.</summary>
    Task<LloydsApiResult<InternationalPaymentResponse>> InitiateInternationalPaymentAsync(
        PaymentRequest request,
        CancellationToken cancellationToken = default);
}
