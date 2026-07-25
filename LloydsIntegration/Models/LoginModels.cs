using System.ComponentModel.DataAnnotations;

namespace LloydsIntegration.Models;

/// <summary>Credentials for POST /api/auth/login — checked against AdminCredentials in appsettings.json.</summary>
public class LoginRequest
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}

/// <summary>The JWT issued on successful login, and when it expires.</summary>
public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAtUtc { get; set; }
}
