using System.Text.Json.Serialization;

namespace Lloyds.Models.Payment.FasterPayment;

/// <summary>Agency Bank only block. Maps to DebtorAgent in bilateral-faster-payment-channel-api-v4.0.0.yaml.</summary>
public class DebtorAgent
{
    [JsonPropertyName("bankOrBusinessIdentificationCode")]
    public string? BankOrBusinessIdentificationCode { get; set; }

    [JsonPropertyName("clearingSystemIdentificationCode")]
    public string? ClearingSystemIdentificationCode { get; set; }

    [JsonPropertyName("clearingSystemMemberIdentification")]
    public string? ClearingSystemMemberIdentification { get; set; }
}
