namespace Lloyds.Models;

/// <summary>Result of a call made to a Lloyds Bank Gem API endpoint.</summary>
public class LloydsApiResult<T>
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string? RawContent { get; set; }
    public string? ErrorMessage { get; set; }

    public static LloydsApiResult<T> Success(int statusCode, T? data, string? rawContent = null) =>
        new() { IsSuccess = true, StatusCode = statusCode, Data = data, RawContent = rawContent };

    public static LloydsApiResult<T> Failure(int statusCode, string errorMessage, string? rawContent = null) =>
        new() { IsSuccess = false, StatusCode = statusCode, ErrorMessage = errorMessage, RawContent = rawContent };
}
