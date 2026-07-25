using System.Text.Json.Serialization;

namespace Lloyds.Models.Reporting.Account;

/// <summary>Maps to YAML definition 'Account' (renamed to avoid colliding with the containing namespace segment).</summary>
public class AccountIdentifier
{
    [JsonPropertyName("identification")]
    public string? Identification { get; set; }

    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }

    [JsonPropertyName("servicer")]
    public Servicer? Servicer { get; set; }
}
