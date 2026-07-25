using LloydsIntegration.Helpers;
using Lloyds.Interfaces;
using Lloyds.Models.AccountManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LloydsIntegration.Controllers;

/// <summary>
/// All Account Management endpoints (Lloyds Bank Gem API Account Management Swaggers_September2023):
/// bilateral-create-account-channel-api-v2.0.0.yaml, bilateral-close-account-channel-api-v2.0.0.yaml.
/// Each action keeps the exact route from its source YAML's basePath.
/// </summary>
[ApiController]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly ICreateAccountService _createAccountService;
    private readonly ICloseAccountService _closeAccountService;

    public AccountController(ICreateAccountService createAccountService, ICloseAccountService closeAccountService)
    {
        _createAccountService = createAccountService;
        _closeAccountService = closeAccountService;
    }

    /// <summary>bilateral-create-account-channel-api-v2.0.0.yaml — POST /create-account (operationId: createAccountsUsingPOST).</summary>
    [HttpPost("/bilateral-create-account-api/v2/create-account")]
    public async Task<IActionResult> CreateAccount(
        [FromBody] CreateAccountRequest createAccountRequest,
        [FromHeader(Name = "x-idempotency-key")] string? xIdempotencyKey,
        CancellationToken cancellationToken)
    {
        var result = await _createAccountService.CreateAccountAsync(createAccountRequest, xIdempotencyKey, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Account created successfully.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to create account.", result.StatusCode);
    }

    /// <summary>bilateral-close-account-channel-api-v2.0.0.yaml — POST /close-accounts (operationId: closeAccountsUsingPOST).</summary>
    [HttpPost("/bilateral-close-account-api/v2/close-accounts")]
    public async Task<IActionResult> CloseAccounts(
        [FromBody] CloseAccountRequest accountRequest,
        [FromHeader(Name = "x-idempotency-key")] string? xIdempotencyKey,
        CancellationToken cancellationToken)
    {
        var result = await _closeAccountService.CloseAccountAsync(accountRequest, xIdempotencyKey, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Account closed successfully.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to close account.", result.StatusCode);
    }
}
