# Lloyds Integration

Internal ASP.NET Core Web API that proxies the **Lloyds Bank Gem** bilateral channel APIs
(Account Management, Payment, Reporting, Token/OAuth). Clients call this API instead of Lloyds
directly; controllers forward requests to Lloyds via the `Lloyds` class library, which owns all
auth, mTLS, JWS signing, and HTTP concerns.

This is a deliberately simple, internal project — no Clean Architecture / CQRS / MediatR /
repository pattern. Controllers call plain service classes.

## Solution structure

```
Lloyds Integration Project/
├── LloydsIntegration.slnx
├── LloydsIntegration/              # ASP.NET Core Web API
│   ├── Controllers/                # AccountController, PaymentController, ReportingController,
│   │                                 TokenController, AuthController (our own login)
│   ├── Models/                     # ApiResponse<T> envelope, login/OAuth DTOs
│   ├── Helpers/                    # ApiResponseHelper, ValidationHelper, DateHelper
│   ├── Configuration/               # JwtSettings, AdminCredentialsSettings
│   ├── Auth/                        # JwtTokenService (issues our own JWTs)
│   ├── Middleware/                  # ExceptionMiddleware (global error handling)
│   ├── Swagger/                     # Swagger/OpenAPI + JWT bearer config
│   ├── Certificates/                # mTLS + JWS signing certs (dummy placeholders — see its README)
│   └── appsettings.json
├── Lloyds/                          # Class library — all Lloyds integration code
│   ├── Interfaces/ + Services/      # One service per Lloyds API (e.g. IChapsPaymentService)
│   ├── Helpers/                     # HttpHelper, TokenHelper, JwsSigner, CertificateHelper, JsonHelper
│   ├── Models/                      # Request/response DTOs, grouped by module/API
│   ├── Configuration/                # LloydsSettings (IOptions<T>)
│   └── Extensions/                  # AddXModule() DI registration per module
└── TODO/                            # Lloyds_Integration_TODO_List.docx — pre-go-live checklist
```

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022 (17.8+) or `dotnet` CLI — the solution uses the newer `.slnx` format

## Getting started

```bash
git clone https://github.com/NileshPrajapatiSIT/Cremello-lloyds-integration-project.git
cd "Cremello-lloyds-integration-project"
dotnet build
dotnet run --project LloydsIntegration
```

Swagger UI opens at `https://localhost:<port>/swagger` in Development. All endpoints except
`POST /api/auth/login` require a bearer token — see below.

## Authentication (our own API, not Lloyds)

1. `POST /api/auth/login` with the hardcoded credentials from `appsettings.json`
   (`AdminCredentials:Username` / `Password`) → returns a JWT.
2. Click **Authorize** in Swagger and paste the token, or send `Authorization: Bearer <token>`
   on every subsequent request.

This is intentionally simple (no Identity/DB) since it's an internal project — see
`Configuration/AdminCredentialsSettings.cs` and `Configuration/JwtSettings.cs`.

## API modules

One controller per Swagger source folder, each action's route matching the Lloyds YAML exactly:

| Controller | Source Swaggers | Example route |
|---|---|---|
| `AccountController` | Account Management | `POST /bilateral-create-account-api/v2/create-account` |
| `PaymentController` | Payment (incl. JWKS) | `POST /bilateral-faster-payment-api/v4/faster-payments` |
| `ReportingController` | Reporting | `POST /bilateral-balance-api/v4/balances` |
| `TokenController` | Token/OAuth | `POST /oauth2/v1/token` |

Every response is wrapped in the common envelope (`Models/ApiResponse.cs`):

```json
{ "success": true, "message": "", "data": { } }
```

## Configuration reference

All settings live in `LloydsIntegration/appsettings.json`. Anything still reading
`REPLACE_WITH_*` or a `dummy` cert **must** be filled in with real values before this can reach
Lloyds — see `TODO/Lloyds_Integration_TODO_List.docx` for the full list and recommended order.

| Section | Key | Purpose |
|---|---|---|
| `Jwt` | `Key`, `Issuer`, `Audience`, `ExpiryMinutes` | Our own JWT issuance |
| `AdminCredentials` | `Username`, `Password` | Hardcoded login for this internal API |
| `Lloyds` | `BaseUrl`, `TokenUrl`, `AuthorizeUrl` | Lloyds gateway hosts |
| `Lloyds` | `ClientId`, `ClientSecret` | OAuth2 client credentials |
| `Lloyds` | `ReportingScope`, `PaymentScope` | OAuth scopes — Reporting vs Payment/Account use different scopes and token TTLs |
| `Lloyds` | `ApiKey` | `x-ibm-client-id` header |
| `Lloyds` | `SystemUserId` | `x-lbg-system-user-id` header |
| `Lloyds` | `TlsCertificatePath/Password` | Mutual TLS client cert to Lloyds' gateway |
| `Lloyds` | `MlsCertificatePath/Password`, `MlsKeyId` | Signs `x-jws-signature` on Payment/Account calls |

## Certificates

Lloyds requires **mutual TLS** on every call plus a **detached JWS signature** on Payment
Initiation and Account Management requests. `LloydsIntegration/Certificates/` currently holds
self-signed placeholder certs so the app runs locally — full replacement instructions are in
`LloydsIntegration/Certificates/README.md`.

## Known gaps / TODOs

See `TODO/Lloyds_Integration_TODO_List.docx` for the complete, prioritized list (certificates,
config placeholders, JWS validation, a couple of judgment calls on ambiguous YAML fields). Nothing
there blocks local development — it all blocks calling the *real* Lloyds gateway.

## Build & run

```bash
dotnet build                                   # whole solution
dotnet run --project LloydsIntegration         # run the API
dotnet run --project LloydsIntegration -- --urls http://localhost:5248
```
