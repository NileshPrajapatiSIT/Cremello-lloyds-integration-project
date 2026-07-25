namespace LloydsIntegration.Configuration;

/// <summary>Hardcoded credentials for this temporary/internal project. No Identity/DB auth required.</summary>
public class AdminCredentialsSettings
{
    public const string SectionName = "AdminCredentials";

    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
