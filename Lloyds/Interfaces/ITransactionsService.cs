using Lloyds.Models;
using Lloyds.Models.Reporting.Transactions;

namespace Lloyds.Interfaces;

/// <summary>Forwards calls to the Lloyds Bilateral Transaction API (bilateral-transactions-payment-channel-api-v5.0.0.yaml).</summary>
public interface ITransactionsService
{
    /// <summary>Maps to POST /transactions (operationId: transactionsUsingPOST).</summary>
    Task<LloydsApiResult<TransactionResponse>> GetTransactionsAsync(
        TransactionRequest request,
        string? pg,
        CancellationToken cancellationToken = default);
}
