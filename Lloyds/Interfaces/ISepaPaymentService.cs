using Lloyds.Models;
using Lloyds.Models.Payment.Sepa;

namespace Lloyds.Interfaces;

/// <summary>Proxies the Bilateral SEPA Payment Initiation API (bilateral-sepa-payment-channel-api-v2.0.0.yaml).</summary>
public interface ISepaPaymentService
{
    /// <summary>POST /sepa-payments - initiate a SEPA Credit Transfer.</summary>
    Task<LloydsApiResult<SepaPaymentResponse>> InitiateSepaPaymentAsync(
        PaymentRequest request,
        CancellationToken cancellationToken = default);
}
