# TODO — replace before real testing/production use

`dummy-tls-cert.pfx` and `dummy-mls-cert.pfx` are locally generated, self-signed placeholder
certificates (password: `DummyCertPass123!`, set in `appsettings.json`). They let the app start
and exercise its mTLS/JWS code paths locally, but Lloyds' gateway will reject them outright.

Per the Lloyds Bank Gem API Technical Implementation Guide (§2–3.8):

1. Generate two real CSRs (RSA 2048, blank passphrase) with Common Names assigned by Lloyds'
   Onboarding & Servicing Team:
   - TLS (mutual TLS transport): `cs-api-<client>-PRD.lloydsbanking.com`
   - MLS (message signing / JWS): `ms-api-<client>.lloydsbanking.com`
2. Submit the CSRs; Lloyds signs and returns the certificates plus your Client ID/Secret and
   System User ID via Secure Email, along with a Key Identifier (`kid`) for the MLS certificate.
3. Keep the private keys — ideally in an HSM — they are never sent to Lloyds.
4. Replace these two dummy `.pfx` files with the real ones (or point
   `Lloyds:TlsCertificatePath` / `Lloyds:MlsCertificatePath` in `appsettings.json` at wherever
   they're actually stored — e.g. a secret store, not committed to source control) and update
   `Lloyds:MlsKeyId` with the real `kid`.

Both certificates are valid for 12 months and must be renewed via a fresh CSR.
