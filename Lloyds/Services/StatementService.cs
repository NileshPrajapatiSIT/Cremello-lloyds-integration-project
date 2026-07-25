using System.Text;
using Lloyds.Configuration;
using Lloyds.Interfaces;
using Lloyds.Models;
using Lloyds.Models.Reporting.Statement;
using Microsoft.Extensions.Options;

namespace Lloyds.Services;

/// <summary>Implements IStatementService against bilateral-statement-channel-api-v4.0.0.yaml.</summary>
public class StatementService : IStatementService
{
    private const string BasePath = "/bilateral-statement-api/v4/statements";

    private readonly IHttpHelper _httpHelper;
    private readonly LloydsSettings _settings;

    public StatementService(IHttpHelper httpHelper, IOptions<LloydsSettings> settings)
    {
        _httpHelper = httpHelper;
        _settings = settings.Value;
    }

    public async Task<LloydsApiResult<StatementUnQualifiedResponse>> GetUnqualifiedStatementsAsync(
        string? channel,
        string? format,
        string? fromStatementDate,
        string? pg,
        string? toStatementDate,
        CancellationToken cancellationToken = default)
    {
        var query = new List<(string Key, string? Value)>
        {
            ("channel", channel),
            ("format", format),
            ("fromStatementDate", fromStatementDate),
            ("pg", pg),
            ("toStatementDate", toStatementDate)
        };

        var headers = new Dictionary<string, string>
        {
            ["x-lbg-system-user-id"] = _settings.SystemUserId
        };

        return await _httpHelper.SendAsync<StatementUnQualifiedResponse>(
            HttpMethod.Get,
            BuildRequestUri(BasePath, query),
            null,
            headers,
            includeBearerToken: true,
            scope: _settings.ReportingScope,
            cancellationToken: cancellationToken);
    }

    public async Task<LloydsApiResult<StatementQualifiedResponse>> GetQualifiedStatementsAsync(
        StatementRequest request,
        string? pg,
        CancellationToken cancellationToken = default)
    {
        var query = new List<(string Key, string? Value)> { ("pg", pg) };

        var headers = new Dictionary<string, string>
        {
            ["x-lbg-system-user-id"] = _settings.SystemUserId
        };

        return await _httpHelper.SendAsync<StatementQualifiedResponse>(
            HttpMethod.Post,
            BuildRequestUri(BasePath, query),
            request,
            headers,
            includeBearerToken: true,
            scope: _settings.ReportingScope,
            cancellationToken: cancellationToken);
    }

    private static string BuildRequestUri(string basePath, IEnumerable<(string Key, string? Value)> query)
    {
        var builder = new StringBuilder(basePath);
        var first = true;

        foreach (var (key, value) in query)
        {
            if (string.IsNullOrEmpty(value))
            {
                continue;
            }

            builder.Append(first ? '?' : '&');
            builder.Append(Uri.EscapeDataString(key)).Append('=').Append(Uri.EscapeDataString(value));
            first = false;
        }

        return builder.ToString();
    }
}
