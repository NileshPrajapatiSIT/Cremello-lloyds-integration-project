using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Account;

/// <summary>Maps to YAML definition 'QualifiedAccountResponse' — response body for POST /accounts.</summary>
public class QualifiedAccountResponse
{
    [JsonPropertyName("data")]
    public QualifiedResponseDataWrapper? Data { get; set; }

    [JsonPropertyName("links")]
    public Links? Links { get; set; }

    [JsonPropertyName("meta")]
    public Meta? Meta { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }
}

/// <summary>Maps to YAML definition 'QualifiedResponseDataWrapper'.</summary>
public class QualifiedResponseDataWrapper
{
    [JsonPropertyName("account")]
    public List<AccountResponseAttributes>? Account { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }
}
