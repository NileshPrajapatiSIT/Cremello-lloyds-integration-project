using System.ComponentModel.DataAnnotations;

namespace LloydsIntegration.Models.OAuth;

/// <summary>Maps to the formData parameters of POST /oauth2/v1/token in lbg-group-oauth-api-1-3-0.yaml.</summary>
public class TokenRequest
{
    [Required]
    public string GrantType { get; set; } = "client_credentials";

    public string? ClientId { get; set; }

    public string? ClientSecret { get; set; }

    public string? Scope { get; set; }
}
