namespace Lloyds.Models.Reporting.Account;

/// <summary>Optional filter query parameters for GET /accounts (unqualified accounts), matching the YAML operation's query parameters exactly.</summary>
public class UnqualifiedAccountsQuery
{
    public string? AccountType { get; set; }

    public string? AccountTypeCode { get; set; }

    public string? Currency { get; set; }

    public string? EntityId { get; set; }

    public string? EntityName { get; set; }

    public string? Name { get; set; }

    public string? Pg { get; set; }

    public string? ProductId { get; set; }

    public string? RoutingId { get; set; }

    public string? ServicerCountry { get; set; }

    public string? ServicerIdentification { get; set; }

    public string? Status { get; set; }

    public string? VirtualAccountEligible { get; set; }

    public string? VirtualAccountUsed { get; set; }

    public string? VirtualBalanceAccountId { get; set; }

    public string? VirtualBalanceAccountName { get; set; }

    public string? VirtualExternallyAddressable { get; set; }
}
