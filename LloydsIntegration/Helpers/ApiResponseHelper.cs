using LloydsIntegration.Models;
using Microsoft.AspNetCore.Mvc;

namespace LloydsIntegration.Helpers;

/// <summary>Builds consistent IActionResult wrappers around ApiResponse&lt;T&gt;.</summary>
public static class ApiResponseHelper
{
    public static ObjectResult Success<T>(T? data, string message = "", int statusCode = StatusCodes.Status200OK) =>
        new(ApiResponse<T>.Ok(data, message)) { StatusCode = statusCode };

    public static ObjectResult Error(string message, int statusCode = StatusCodes.Status400BadRequest) =>
        new(ApiResponse.Fail(message)) { StatusCode = statusCode };
}
