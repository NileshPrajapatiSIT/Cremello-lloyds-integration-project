using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Reporting.Balance;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements IBalanceService against the Lloyds Bilateral Balance Api described in bilateral-balance-channel-api-v4.0.0.yaml.</summary>
public class BalanceService : IBalanceService
{
    private const string BasePath = "/bilateral-balance-api/v4";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public BalanceService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public async Task<LloydsApiResult<BalanceResponse>> GetBalancesAsync(
        BalanceRequest? request,
        string? pg,
        CancellationToken cancellationToken = default)
    {
        var requestUri = $"{BasePath}/balances";
        if (!string.IsNullOrEmpty(pg))
        {
            requestUri += $"?pg={Uri.EscapeDataString(pg)}";
        }

        var headers = new Dictionary<string, string>
        {
            ["x-ibm-client-id"] = _settings.ApiKey,
            ["x-lbg-system-user-id"] = _settings.SystemUserId
        };

        return await _httpHelper.SendAsync<BalanceResponse>(
            HttpMethod.Post,
            requestUri,
            body: request,
            headers: headers,
            scope: _settings.ReportingScope,
            cancellationToken: cancellationToken);
    }
}
