using Lloyds.Models;
using Lloyds.Models.Payment.PaymentStatus;

namespace Lloyds.Interfaces;

/// <summary>Proxies the Bilateral Payment Or Transfer Status API (bilateral-payment-status-channel-api-v3.0.0.yaml).</summary>
public interface IPaymentStatusService
{
    /// <summary>GET /bilateral-payment-status-api/v3/payment-status — fetches the status of a payment or transfer.</summary>
    Task<LloydsApiResult<PaymentStatusResponse>> GetPaymentStatusAsync(
        string paymentOrderIdentification,
        CancellationToken cancellationToken = default);
}
