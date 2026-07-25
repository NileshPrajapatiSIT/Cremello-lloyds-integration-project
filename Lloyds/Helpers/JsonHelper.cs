using System.Text.Json;

namespace Lloyds.Helpers;

/// <summary>Shared JSON serialization helpers to avoid re-creating JsonSerializerOptions everywhere.</summary>
public static class JsonHelper
{
    public static readonly JsonSerializerOptions DefaultOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    public static string Serialize<T>(T value) => JsonSerializer.Serialize(value, DefaultOptions);

    public static T? Deserialize<T>(string json) =>
        string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.Deserialize<T>(json, DefaultOptions);
}
