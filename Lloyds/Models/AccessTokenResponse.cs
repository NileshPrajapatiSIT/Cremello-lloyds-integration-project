using System.Text.Json.Serialization;

namespace Lloyds.Models;

/// <summary>Maps to the `access_token_response` schema in lbg-group-oauth-api-1-3-0.yaml.</summary>
public class AccessTokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = string.Empty;

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("consented_on")]
    public string ConsentedOn { get; set; } = string.Empty;

    [JsonPropertyName("scope")]
    public string Scope { get; set; } = string.Empty;
}
