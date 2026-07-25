using Lloyds.Models;
using Lloyds.Models.AccountManagement;

namespace Lloyds.Interfaces;

/// <summary>Forwards calls to the Lloyds Bilateral Create Account API (bilateral-create-account-channel-api-v2.0.0.yaml).</summary>
public interface ICreateAccountService
{
    /// <summary>Maps to POST /create-account (operationId: createAccountsUsingPOST).</summary>
    Task<LloydsApiResult<CreateAccountResponse>> CreateAccountAsync(
        CreateAccountRequest request,
        string? idempotencyKey = null,
        CancellationToken cancellationToken = default);
}
