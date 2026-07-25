using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Balance;

/// <summary>Maps to YAML definition 'BalanceRequest' — optional request body for POST /balances. An empty/omitted body means an unqualified request.</summary>
public class BalanceRequest
{
    [JsonPropertyName("data")]
    public RequestDataWrapper? Data { get; set; }
}

/// <summary>Maps to YAML definition 'RequestDataWrapper'.</summary>
public class RequestDataWrapper
{
    [JsonPropertyName("account")]
    public List<AccountIdentifier>? Account { get; set; }

    [JsonPropertyName("filter")]
    public BalanceFilter? Filter { get; set; }
}
