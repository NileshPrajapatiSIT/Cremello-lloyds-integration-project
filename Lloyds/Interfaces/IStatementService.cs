using Lloyds.Models;
using Lloyds.Models.Reporting.Statement;

namespace Lloyds.Interfaces;

/// <summary>Forwards calls to the Lloyds Bilateral Statement API (bilateral-statement-channel-api-v4.0.0.yaml).</summary>
public interface IStatementService
{
    /// <summary>Maps to GET /statements (operationId: unQualifiedStatementUsingGET).</summary>
    Task<LloydsApiResult<StatementUnQualifiedResponse>> GetUnqualifiedStatementsAsync(
        string? channel,
        string? format,
        string? fromStatementDate,
        string? pg,
        string? toStatementDate,
        CancellationToken cancellationToken = default);

    /// <summary>Maps to POST /statements (operationId: qualifiedStatementsUsingPOST).</summary>
    Task<LloydsApiResult<StatementQualifiedResponse>> GetQualifiedStatementsAsync(
        StatementRequest request,
        string? pg,
        CancellationToken cancellationToken = default);
}
