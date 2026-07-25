using System.ComponentModel.DataAnnotations;

namespace LloydsIntegration.Models.OAuth;

/// <summary>Maps to the query parameters of GET /oauth2/v1/authorize in lbg-group-oauth-api-1-3-0.yaml.</summary>
public class AuthorizeRequest
{
    /// <summary>"code" (Authorization Code grant) or "token" (Implicit grant).</summary>
    [Required]
    public string ResponseType { get; set; } = string.Empty;

    [Required]
    public string ClientId { get; set; } = string.Empty;

    [Required]
    public string Scope { get; set; } = string.Empty;

    public string? RedirectUri { get; set; }

    public string? State { get; set; }
}
