using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Reporting.Transactions;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements ITransactionsService against bilateral-transactions-payment-channel-api-v5.0.0.yaml.</summary>
public class TransactionsService : ITransactionsService
{
    private const string BasePath = "/bilateral-transaction-api/v5/transactions";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public TransactionsService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public async Task<LloydsApiResult<TransactionResponse>> GetTransactionsAsync(
        TransactionRequest request,
        string? pg,
        CancellationToken cancellationToken = default)
    {
        var requestUri = string.IsNullOrEmpty(pg)
            ? BasePath
            : $"{BasePath}?pg={Uri.EscapeDataString(pg)}";

        var headers = new Dictionary<string, string>
        {
            ["x-lbg-system-user-id"] = _settings.SystemUserId
        };

        return await _httpHelper.SendAsync<TransactionResponse>(
            HttpMethod.Post,
            requestUri,
            request,
            headers,
            includeBearerToken: true,
            scope: _settings.ReportingScope,
            cancellationToken: cancellationToken);
    }
}
