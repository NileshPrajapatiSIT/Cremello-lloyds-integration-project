namespace LloydsIntegration.Configuration;

/// <summary>Signing config for the JWTs this API issues from /api/auth/login (not related to Lloyds' own OAuth).</summary>
public class JwtSettings
{
    public const string SectionName = "Jwt";

    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpiryMinutes { get; set; } = 60;
}
