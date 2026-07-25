using Lloyds.Models;
using Lloyds.Models.Reporting.StatementRetrieve;

namespace Lloyds.Interfaces;

/// <summary>Forwards calls to the Lloyds Bilateral Statement Retrieve API (bilateral-statement-retrieve-channel-api-v3.0.0.yaml).</summary>
public interface IStatementRetrieveService
{
    /// <summary>Maps to GET /statement-retrieve/{id} (operationId: statementRetrieveUsingGET).</summary>
    Task<LloydsApiResult<StatementRetrieveItemResponse>> GetStatementAsync(
        string id,
        CancellationToken cancellationToken = default);
}
