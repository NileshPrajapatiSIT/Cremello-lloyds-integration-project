using Lloyds.Models;
using Lloyds.Models.Reporting.Balance;

namespace Lloyds.Interfaces;

/// <summary>Proxies the Lloyds Bilateral Balance Api (bilateral-balance-channel-api-v4.0.0.yaml, basePath /bilateral-balance-api/v4).</summary>
public interface IBalanceService
{
    /// <summary>POST /balances — qualified, bulk qualified, or unqualified balance lookup depending on the request body contents.</summary>
    Task<LloydsApiResult<BalanceResponse>> GetBalancesAsync(
        BalanceRequest? request,
        string? pg,
        CancellationToken cancellationToken = default);
}
