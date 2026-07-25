using System.Text.RegularExpressions;

namespace LloydsIntegration.Helpers;

/// <summary>Small reusable validation checks used across controllers/services.</summary>
public static partial class ValidationHelper
{
    public static bool IsValidSortCodeAccountNumber(string? value) =>
        !string.IsNullOrWhiteSpace(value) && SortCodeAccountNumberRegex().IsMatch(value);

    public static bool IsValidIban(string? value) =>
        !string.IsNullOrWhiteSpace(value) && IbanRegex().IsMatch(value.Replace(" ", string.Empty));

    public static bool IsValidCurrencyCode(string? value) =>
        !string.IsNullOrWhiteSpace(value) && CurrencyCodeRegex().IsMatch(value);

    [GeneratedRegex("^[0-9]{14}$")]
    private static partial Regex SortCodeAccountNumberRegex();

    [GeneratedRegex("^[A-Z]{2}[0-9]{2}[A-Z0-9]{1,30}$")]
    private static partial Regex IbanRegex();

    [GeneratedRegex("^[A-Z]{3}$")]
    private static partial Regex CurrencyCodeRegex();
}
