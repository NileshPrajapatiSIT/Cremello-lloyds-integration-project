using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Balance;

/// <summary>Maps to YAML definition 'BalanceResponse' — response body for POST /balances.</summary>
public class BalanceResponse
{
    [JsonPropertyName("data")]
    public ResponseDataWrapper? Data { get; set; }

    [JsonPropertyName("links")]
    public Links? Links { get; set; }

    [JsonPropertyName("meta")]
    public Meta? Meta { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }
}

/// <summary>Maps to YAML definition 'ResponseDataWrapper'.</summary>
public class ResponseDataWrapper
{
    [JsonPropertyName("balance")]
    public List<BalanceDetail>? Balance { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorData>? Errors { get; set; }

    [JsonPropertyName("filter")]
    public BalanceFilter? Filter { get; set; }
}
