using System.Globalization;

namespace LloydsIntegration.Helpers;

/// <summary>Date formatting helpers matching the ISO 8601 date/date-time formats used throughout the Lloyds APIs.</summary>
public static class DateHelper
{
    public const string DateFormat = "yyyy-MM-dd";
    public const string DateTimeOffsetFormat = "yyyy-MM-ddTHH:mm:sszzz";

    public static string ToIsoDate(DateOnly date) => date.ToString(DateFormat, CultureInfo.InvariantCulture);

    public static string ToIsoDateTime(DateTimeOffset dateTime) => dateTime.ToString(DateTimeOffsetFormat, CultureInfo.InvariantCulture);

    public static bool TryParseIsoDate(string? value, out DateOnly date) =>
        DateOnly.TryParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
}
