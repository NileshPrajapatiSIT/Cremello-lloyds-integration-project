using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Account;

/// <summary>Maps to YAML definition 'UnQualifiedAccountResponse' — response body for GET /accounts.</summary>
public class UnQualifiedAccountResponse
{
    [JsonPropertyName("data")]
    public UnQualifiedResponseDataWrapper? Data { get; set; }

    [JsonPropertyName("links")]
    public Links? Links { get; set; }

    [JsonPropertyName("meta")]
    public Meta? Meta { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }
}

/// <summary>Maps to YAML definition 'UnQualifiedResponseDataWrapper'.</summary>
public class UnQualifiedResponseDataWrapper
{
    [JsonPropertyName("account")]
    public List<AccountResponseAttributes>? Account { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }

    [JsonPropertyName("filter")]
    public FilterParam? Filter { get; set; }
}
