using Lloyds.Models;
using Lloyds.Models.Reporting.Account;

namespace Lloyds.Interfaces;

/// <summary>Proxies the Lloyds Bilateral Account Api (bilateral-account-channel-api-v4.0.0.yaml, basePath /bilateral-account-api/v4).</summary>
public interface IAccountReportingService
{
    /// <summary>GET /accounts — unqualified accounts, optionally narrowed by filter query parameters.</summary>
    Task<LloydsApiResult<UnQualifiedAccountResponse>> GetUnqualifiedAccountsAsync(
        UnqualifiedAccountsQuery query,
        CancellationToken cancellationToken = default);

    /// <summary>POST /accounts — qualified (single or bulk, up to 25 accounts) account lookup.</summary>
    Task<LloydsApiResult<QualifiedAccountResponse>> GetQualifiedAccountsAsync(
        AccountRequest request,
        CancellationToken cancellationToken = default);
}
