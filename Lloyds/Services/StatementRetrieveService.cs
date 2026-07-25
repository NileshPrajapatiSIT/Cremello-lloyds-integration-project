using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Reporting.StatementRetrieve;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements IStatementRetrieveService against bilateral-statement-retrieve-channel-api-v3.0.0.yaml.</summary>
public class StatementRetrieveService : IStatementRetrieveService
{
    private const string BasePath = "/bilateral-statement-retrieve-api/v3/statement-retrieve";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public StatementRetrieveService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public async Task<LloydsApiResult<StatementRetrieveItemResponse>> GetStatementAsync(
        string id,
        CancellationToken cancellationToken = default)
    {
        var headers = new Dictionary<string, string>
        {
            ["x-lbg-system-user-id"] = _settings.SystemUserId
        };

        return await _httpHelper.SendAsync<StatementRetrieveItemResponse>(
            HttpMethod.Get,
            $"{BasePath}/{Uri.EscapeDataString(id)}",
            null,
            headers,
            includeBearerToken: true,
            scope: _settings.ReportingScope,
            cancellationToken: cancellationToken);
    }
}
