using LloydsIntegration.Helpers;
using LloydsIntegration.Models;
using Lloyds.Interfaces;
using Lloyds.Models.Reporting.Account;
using Lloyds.Models.Reporting.Balance;
using Lloyds.Models.Reporting.Statement;
using Lloyds.Models.Reporting.StatementRetrieve;
using Lloyds.Models.Reporting.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LloydsIntegration.Controllers;

/// <summary>
/// All Reporting endpoints (Lloyds Bank Gem API Reporting Swaggers_September2023): account, balance, statement,
/// statement-retrieve, transactions. Each action keeps the exact route from its source YAML's basePath.
/// </summary>
[ApiController]
[Authorize]
public class ReportingController : ControllerBase
{
    private readonly IAccountReportingService _accountReportingService;
    private readonly IBalanceService _balanceService;
    private readonly IStatementService _statementService;
    private readonly IStatementRetrieveService _statementRetrieveService;
    private readonly ITransactionsService _transactionsService;

    public ReportingController(
        IAccountReportingService accountReportingService,
        IBalanceService balanceService,
        IStatementService statementService,
        IStatementRetrieveService statementRetrieveService,
        ITransactionsService transactionsService)
    {
        _accountReportingService = accountReportingService;
        _balanceService = balanceService;
        _statementService = statementService;
        _statementRetrieveService = statementRetrieveService;
        _transactionsService = transactionsService;
    }

    /// <summary>bilateral-account-channel-api-v4.0.0.yaml — GET /accounts (unqualified, optionally filtered).</summary>
    [HttpGet("/bilateral-account-api/v4/accounts")]
    public async Task<IActionResult> GetUnqualifiedAccounts([FromQuery] UnqualifiedAccountsQuery query, CancellationToken cancellationToken)
    {
        var result = await _accountReportingService.GetUnqualifiedAccountsAsync(query, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Accounts retrieved.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to retrieve accounts.", result.StatusCode);
    }

    /// <summary>bilateral-account-channel-api-v4.0.0.yaml — POST /accounts (qualified lookup, single or up to 25 accounts).</summary>
    [HttpPost("/bilateral-account-api/v4/accounts")]
    public async Task<IActionResult> GetQualifiedAccounts([FromBody] AccountRequest request, CancellationToken cancellationToken)
    {
        var result = await _accountReportingService.GetQualifiedAccountsAsync(request, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Accounts retrieved.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to retrieve accounts.", result.StatusCode);
    }

    /// <summary>bilateral-balance-channel-api-v4.0.0.yaml — POST /balances (qualified, bulk qualified, or unqualified depending on body).</summary>
    [HttpPost("/bilateral-balance-api/v4/balances")]
    public async Task<IActionResult> GetBalances([FromBody] BalanceRequest? request, [FromQuery(Name = "pg")] string? pg, CancellationToken cancellationToken)
    {
        var result = await _balanceService.GetBalancesAsync(request, pg, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Balances retrieved.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to retrieve balances.", result.StatusCode);
    }

    /// <summary>bilateral-statement-channel-api-v4.0.0.yaml — GET /statements (unqualified search across all entitled accounts).</summary>
    [HttpGet("/bilateral-statement-api/v4/statements")]
    [ProducesResponseType(typeof(ApiResponse<StatementUnQualifiedResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUnqualifiedStatements(
        [FromQuery] string? channel,
        [FromQuery] string? format,
        [FromQuery] string? fromStatementDate,
        [FromQuery] string? pg,
        [FromQuery] string? toStatementDate,
        CancellationToken cancellationToken)
    {
        var result = await _statementService.GetUnqualifiedStatementsAsync(channel, format, fromStatementDate, pg, toStatementDate, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Statements retrieved.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to retrieve statements.", result.StatusCode == 0 ? StatusCodes.Status502BadGateway : result.StatusCode);
    }

    /// <summary>bilateral-statement-channel-api-v4.0.0.yaml — POST /statements (qualified search for specified accounts).</summary>
    [HttpPost("/bilateral-statement-api/v4/statements")]
    [ProducesResponseType(typeof(ApiResponse<StatementQualifiedResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetQualifiedStatements(
        [FromQuery] string? pg,
        [FromBody] StatementRequest statementRequest,
        CancellationToken cancellationToken)
    {
        var result = await _statementService.GetQualifiedStatementsAsync(statementRequest, pg, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Statements retrieved.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to retrieve statements.", result.StatusCode == 0 ? StatusCodes.Status502BadGateway : result.StatusCode);
    }

    /// <summary>bilateral-statement-retrieve-channel-api-v3.0.0.yaml — GET /statement-retrieve/{id}.
    /// NOTE: the Lloyds response is a JSON envelope whose "data.statementFile.file" field carries the statement
    /// content as a BASE64 string, not a raw binary HTTP body, so this is proxied via the standard JSON envelope
    /// rather than File().</summary>
    [HttpGet("/bilateral-statement-retrieve-api/v3/statement-retrieve/{id}")]
    [ProducesResponseType(typeof(ApiResponse<StatementRetrieveItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetStatement([FromRoute] string id, CancellationToken cancellationToken)
    {
        var result = await _statementRetrieveService.GetStatementAsync(id, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Statement retrieved.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to retrieve statement.", result.StatusCode == 0 ? StatusCodes.Status502BadGateway : result.StatusCode);
    }

    /// <summary>bilateral-transactions-payment-channel-api-v5.0.0.yaml — POST /transactions.</summary>
    [HttpPost("/bilateral-transaction-api/v5/transactions")]
    [ProducesResponseType(typeof(ApiResponse<TransactionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTransactions(
        [FromQuery] string? pg,
        [FromBody] TransactionRequest transactionRequest,
        CancellationToken cancellationToken)
    {
        var result = await _transactionsService.GetTransactionsAsync(transactionRequest, pg, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Transactions retrieved.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to retrieve transactions.", result.StatusCode == 0 ? StatusCodes.Status502BadGateway : result.StatusCode);
    }
}
