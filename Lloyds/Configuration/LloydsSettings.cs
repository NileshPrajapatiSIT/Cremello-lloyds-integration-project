namespace Lloyds.Configuration;

/// <summary>Strongly typed configuration for all outbound calls to Lloyds Bank Gem APIs.</summary>
public class LloydsSettings
{
    public const string SectionName = "Lloyds";

    /// <summary>Base URL for the bilateral channel APIs (account, payment, reporting).</summary>
    public string BaseUrl { get; set; } = string.Empty;

    /// <summary>OAuth2 token endpoint, e.g. https://.../oauth2/v1/token.</summary>
    public string TokenUrl { get; set; } = string.Empty;

    /// <summary>OAuth2 authorization endpoint, e.g. https://.../oauth2/v1/authorize.</summary>
    public string AuthorizeUrl { get; set; } = string.Empty;

    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;

    /// <summary>Default scope used only by the raw OAuth passthrough (TokenController) when a caller omits one.</summary>
    public string Scope { get; set; } = string.Empty;

    /// <summary>
    /// OAuth scope for Information/Reporting APIs, per Lloyds Bank Gem API Technical Implementation Guide §5.1.2.
    /// Token TTL for this scope is ~90 days.
    /// </summary>
    public string ReportingScope { get; set; } = "commercial_account";

    /// <summary>
    /// OAuth scope for Payment Initiation and Account Management APIs, per Lloyds Bank Gem API Technical
    /// Implementation Guide §5.1.2. Token TTL for this scope is ~1 hour.
    /// </summary>
    public string PaymentScope { get; set; } = "commercial_payment";

    /// <summary>x-ibm-client-id / X-IBM-Client-Id header value used by several Lloyds APIs (e.g. JWKS).</summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>Static identifier of the calling system, sent as x-lbg-system-user-id on payment initiation calls.</summary>
    public string SystemUserId { get; set; } = string.Empty;

    public int TimeoutSeconds { get; set; } = 30;

    public string Environment { get; set; } = "Sandbox";

    /// <summary>
    /// TLS client certificate (CN cs-api-&lt;client&gt;-PRD.lloydsbanking.com per the Technical Implementation
    /// Guide §2-3.8) used for mutual TLS to Lloyds' API gateway. PFX path + password.
    /// TODO: replace the dummy self-signed cert under Certificates/ with the real Lloyds-issued TLS certificate
    /// once your CSR has been signed and returned.
    /// </summary>
    public string TlsCertificatePath { get; set; } = string.Empty;

    public string TlsCertificatePassword { get; set; } = string.Empty;

    /// <summary>
    /// MLS (Message Layer Security) certificate (CN ms-api-&lt;client&gt;.lloydsbanking.com) whose private key
    /// signs request payloads as a detached JWS in the x-jws-signature header, required on Payment Initiation
    /// and Account Management calls. PFX path + password.
    /// TODO: replace the dummy self-signed cert under Certificates/ with the real Lloyds-issued MLS certificate.
    /// </summary>
    public string MlsCertificatePath { get; set; } = string.Empty;

    public string MlsCertificatePassword { get; set; } = string.Empty;

    /// <summary>Key Identifier (kid) issued by Lloyds alongside the MLS certificate, included in the JWS header.</summary>
    public string MlsKeyId { get; set; } = string.Empty;
}
