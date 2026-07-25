using LloydsIntegration.Auth;
using LloydsIntegration.Configuration;
using LloydsIntegration.Helpers;
using LloydsIntegration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LloydsIntegration.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly AdminCredentialsSettings _adminCredentials;

    public AuthController(IJwtTokenService jwtTokenService, IOptions<AdminCredentialsSettings> adminCredentials)
    {
        _jwtTokenService = jwtTokenService;
        _adminCredentials = adminCredentials.Value;
    }

    /// <summary>Authenticates against the hardcoded admin credentials configured in appsettings.json and returns a JWT.</summary>
    [HttpPost("login")]
    [ProducesResponseType(typeof(ApiResponse<LoginResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Username != _adminCredentials.Username || request.Password != _adminCredentials.Password)
        {
            return ApiResponseHelper.Error("Invalid username or password.", StatusCodes.Status401Unauthorized);
        }

        var (token, expiresAtUtc) = _jwtTokenService.GenerateToken(request.Username);

        return ApiResponseHelper.Success(new LoginResponse { Token = token, ExpiresAtUtc = expiresAtUtc }, "Login successful.");
    }
}
