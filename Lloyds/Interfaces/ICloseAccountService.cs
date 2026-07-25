using Lloyds.Models;
using Lloyds.Models.AccountManagement;

namespace Lloyds.Interfaces;

/// <summary>Forwards calls to the Lloyds Bilateral Close Account API (bilateral-close-account-channel-api-v2.0.0.yaml).</summary>
public interface ICloseAccountService
{
    /// <summary>Maps to POST /close-accounts (operationId: closeAccountsUsingPOST).</summary>
    Task<LloydsApiResult<CloseAccountResponse>> CloseAccountAsync(
        CloseAccountRequest request,
        string? idempotencyKey = null,
        CancellationToken cancellationToken = default);
}
