using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Structured address used for Debtor/UltimateDebtor. Maps to PostalAddress in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class PostalAddress
{
    [JsonPropertyName("addressType")]
    public string? AddressType { get; set; }

    [JsonPropertyName("buildingNumber")]
    public string? BuildingNumber { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("countrySubDivision")]
    public string? CountrySubDivision { get; set; }

    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [JsonPropertyName("postCode")]
    public string? PostCode { get; set; }

    [JsonPropertyName("streetName")]
    public string? StreetName { get; set; }

    [JsonPropertyName("subDepartment")]
    public string? SubDepartment { get; set; }

    [JsonPropertyName("townName")]
    public string? TownName { get; set; }
}
