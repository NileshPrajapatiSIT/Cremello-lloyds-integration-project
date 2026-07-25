using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Reporting.Account;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements IAccountReportingService against the Lloyds Bilateral Account Api described in bilateral-account-channel-api-v4.0.0.yaml.</summary>
public class AccountReportingService : IAccountReportingService
{
    private const string BasePath = "/bilateral-account-api/v4";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public AccountReportingService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public async Task<LloydsApiResult<UnQualifiedAccountResponse>> GetUnqualifiedAccountsAsync(
        UnqualifiedAccountsQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryParameters = new List<(string Name, string? Value)>
        {
            ("accountType", query.AccountType),
            ("accountTypeCode", query.AccountTypeCode),
            ("currency", query.Currency),
            ("entityId", query.EntityId),
            ("entityName", query.EntityName),
            ("name", query.Name),
            ("pg", query.Pg),
            ("productId", query.ProductId),
            ("routingId", query.RoutingId),
            ("servicerCountry", query.ServicerCountry),
            ("servicerIdentification", query.ServicerIdentification),
            ("status", query.Status),
            ("virtualAccountEligible", query.VirtualAccountEligible),
            ("virtualAccountUsed", query.VirtualAccountUsed),
            ("virtualBalanceAccountId", query.VirtualBalanceAccountId),
            ("virtualBalanceAccountName", query.VirtualBalanceAccountName),
            ("virtualExternallyAddressable", query.VirtualExternallyAddressable)
        };

        var requestUri = $"{BasePath}/accounts{BuildQueryString(queryParameters)}";

        return await _httpHelper.SendAsync<UnQualifiedAccountResponse>(
            HttpMethod.Get,
            requestUri,
            body: null,
            headers: BuildHeaders(),
            scope: _settings.ReportingScope,
            cancellationToken: cancellationToken);
    }

    public async Task<LloydsApiResult<QualifiedAccountResponse>> GetQualifiedAccountsAsync(
        AccountRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestUri = $"{BasePath}/accounts";

        return await _httpHelper.SendAsync<QualifiedAccountResponse>(
            HttpMethod.Post,
            requestUri,
            body: request,
            headers: BuildHeaders(),
            scope: _settings.ReportingScope,
            cancellationToken: cancellationToken);
    }

    private IDictionary<string, string> BuildHeaders() => new Dictionary<string, string>
    {
        ["x-ibm-client-id"] = _settings.ApiKey,
        ["x-lbg-system-user-id"] = _settings.SystemUserId
    };

    private static string BuildQueryString(IEnumerable<(string Name, string? Value)> parameters)
    {
        var pairs = parameters
            .Where(p => !string.IsNullOrEmpty(p.Value))
            .Select(p => $"{p.Name}={Uri.EscapeDataString(p.Value!)}")
            .ToList();

        return pairs.Count == 0 ? string.Empty : $"?{string.Join("&", pairs)}";
    }
}
