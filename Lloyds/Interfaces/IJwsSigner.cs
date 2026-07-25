namespace Lloyds.Interfaces;

/// <summary>Produces the detached JWS signature Lloyds requires (x-jws-signature header) on Payment Initiation
/// and Account Management requests, signed with the MLS certificate's private key.</summary>
public interface IJwsSigner
{
    /// <summary>Returns the detached JWS for the given raw JSON request body, or null if no MLS signing
    /// certificate is configured yet (see Certificates/README.md).</summary>
    string? SignPayload(string jsonPayload);
}
