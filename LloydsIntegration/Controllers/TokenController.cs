using LloydsIntegration.Helpers;
using LloydsIntegration.Models;
using LloydsIntegration.Models.OAuth;
using Lloyds.Interfaces;
using Lloyds.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LloydsIntegration.Controllers;

/// <summary>
/// All Token endpoints (Lloyds Bank Gem API Token Swagger_March2025): lbg-group-oauth-api-1-3-0.yaml (basePath /oauth2/v1).
/// </summary>
[ApiController]
[Authorize]
[Route("oauth2/v1")]
public class TokenController : ControllerBase
{
    private readonly ILloydsOAuthService _oAuthService;

    public TokenController(ILloydsOAuthService oAuthService)
    {
        _oAuthService = oAuthService;
    }

    /// <summary>POST /oauth2/v1/token — Request Access Tokens (client_credentials grant).</summary>
    [HttpPost("token")]
    [Consumes("application/x-www-form-urlencoded")]
    [ProducesResponseType(typeof(ApiResponse<AccessTokenResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RequestToken([FromForm] TokenRequest request, CancellationToken cancellationToken)
    {
        var result = await _oAuthService.RequestTokenAsync(request.GrantType, request.ClientId, request.ClientSecret, request.Scope, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Access token issued.")
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to obtain access token.", result.StatusCode == 0 ? StatusCodes.Status401Unauthorized : result.StatusCode);
    }

    /// <summary>GET /oauth2/v1/authorize — Authorization Code / Implicit grant entry point. Redirects to the Lloyds-hosted authorization page.</summary>
    [HttpGet("authorize")]
    public IActionResult Authorize([FromQuery] AuthorizeRequest request)
    {
        var url = _oAuthService.BuildAuthorizeUrl(request.ResponseType, request.ClientId, request.Scope, request.RedirectUri, request.State);
        return Redirect(url);
    }

    /// <summary>POST /oauth2/v1/authorize — Submit approval for an Authorization Code / Implicit grant.</summary>
    [HttpPost("authorize")]
    public IActionResult SubmitAuthorization()
    {
        // TODO: This endpoint submits end-user approval on Lloyds' own hosted authorization page and requires an
        // interactive browser session against Lloyds' authorization server; it cannot be meaningfully proxied
        // server-to-server. Implement only if Lloyds provides a documented headless approval flow.
        return ApiResponseHelper.Error("Not implemented: interactive authorization approval must be completed on Lloyds' hosted page.", StatusCodes.Status501NotImplemented);
    }
}
