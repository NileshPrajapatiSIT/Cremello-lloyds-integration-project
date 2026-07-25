namespace LloydsIntegration.Models;

/// <summary>Common response envelope used by every controller action.</summary>
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public static ApiResponse<T> Ok(T? data, string message = "") =>
        new() { Success = true, Message = message, Data = data };

    public static ApiResponse<T> Fail(string message, T? data = default) =>
        new() { Success = false, Message = message, Data = data };
}

/// <summary>Non-generic variant for actions that return no payload.</summary>
public class ApiResponse : ApiResponse<object?>
{
    public static ApiResponse Ok(string message = "") =>
        new() { Success = true, Message = message, Data = null };

    public static ApiResponse Fail(string message) =>
        new() { Success = false, Message = message, Data = null };
}
