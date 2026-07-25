using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Account;

/// <summary>Maps to YAML definition 'AccountRequest' — request body for POST /accounts (qualified accounts).</summary>
public class AccountRequest
{
    [JsonPropertyName("data")]
    public RequestDataWrapper? Data { get; set; }
}

/// <summary>Maps to YAML definition 'RequestDataWrapper'.</summary>
public class RequestDataWrapper
{
    [JsonPropertyName("account")]
    public List<AccountIdentifier>? Account { get; set; }
}
