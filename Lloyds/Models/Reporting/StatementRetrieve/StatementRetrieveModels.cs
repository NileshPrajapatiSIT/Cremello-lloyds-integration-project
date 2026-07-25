using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.StatementRetrieve;

// Models for bilateral-statement-retrieve-channel-api-v3.0.0.yaml (basePath /bilateral-statement-retrieve-api/v3).
// Covers GET /statement-retrieve/{id} (statementRetrieveUsingGET).

/// <summary>Maps to definitions/AdditionalInfo.</summary>
public class StatementRetrieveAdditionalInfo
{
    [JsonPropertyName("fieldName")]
    public string? FieldName { get; set; }

    [JsonPropertyName("fieldValue")]
    public string? FieldValue { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("narrative")]
    public string Narrative { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/ErrorData.</summary>
public class StatementRetrieveErrorData
{
    [JsonPropertyName("additionalInformation")]
    public StatementRetrieveAdditionalInfo? AdditionalInformation { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("reasonCode")]
    public string ReasonCode { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/StatementFile.
/// NOTE: "file" carries the statement content as a BASE64 encoded string embedded inside the JSON body
/// (not a raw binary HTTP response), so this is proxied as-is via the standard ApiResponse&lt;T&gt; JSON
/// envelope rather than via File()/binary content-type. Decode "file" client-side if raw bytes are needed.</summary>
public class StatementRetrieveFile
{
    /// <summary>Required. Statement file content in BASE64 encoded binary format.</summary>
    [JsonPropertyName("file")]
    public string File { get; set; } = string.Empty;

    /// <summary>Required.</summary>
    [JsonPropertyName("statementId")]
    public string StatementId { get; set; } = string.Empty;
}

/// <summary>Maps to definitions/ResponseDataWrapper.</summary>
public class StatementRetrieveResponseDataWrapper
{
    [JsonPropertyName("errors")]
    public List<StatementRetrieveErrorData>? Errors { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("statementFile")]
    public StatementRetrieveFile StatementFile { get; set; } = new();
}

/// <summary>Response body for GET /statement-retrieve/{id}. Maps to definitions/BLStatementItemResponse.</summary>
public class StatementRetrieveItemResponse
{
    [JsonPropertyName("data")]
    public StatementRetrieveResponseDataWrapper? Data { get; set; }

    [JsonPropertyName("errors")]
    public List<StatementRetrieveErrorData>? Errors { get; set; }
}

/// <summary>Maps to definitions/GatewayError (title: ErrorResponse). Returned on 401/404/405/406/429/503.</summary>
public class StatementRetrieveGatewayError
{
    /// <summary>Required.</summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    // TODO: YAML declares "errors" as type: string but with "items" referencing ErrorData, which is
    // inconsistent in the spec (looks like it should be an array). Modeled as a nullable string per the
    // literal declared type.
    [JsonPropertyName("errors")]
    public string? Errors { get; set; }

    /// <summary>Required.</summary>
    [JsonPropertyName("httpReason")]
    public string HttpReason { get; set; } = string.Empty;
}
