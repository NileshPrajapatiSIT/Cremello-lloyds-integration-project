using Lloyds.Models;
using Lloyds.Models.Payment.Transfer;

namespace Lloyds.Interfaces;

/// <summary>Proxies the Bilateral Transfer Initiation API (bilateral-transfer-channel-api-v3.0.0.yaml).</summary>
public interface ITransferService
{
    /// <summary>POST /transfers - initiate an internal Transfer within Lloyds.</summary>
    Task<LloydsApiResult<TransferPaymentResponse>> InitiateTransferAsync(
        PaymentRequest request,
        CancellationToken cancellationToken = default);
}
