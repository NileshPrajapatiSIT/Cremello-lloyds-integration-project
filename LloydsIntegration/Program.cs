using System.Text;
using LloydsIntegration.Auth;
using LloydsIntegration.Configuration;
using LloydsIntegration.Middleware;
using LloydsIntegration.Swagger;
using Lloyds.Configuration;
using Lloyds.Extensions;
using Lloyds.Helpers;
using Lloyds.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));
builder.Services.Configure<AdminCredentialsSettings>(builder.Configuration.GetSection(AdminCredentialsSettings.SectionName));
builder.Services.Configure<LloydsSettings>(builder.Configuration.GetSection(LloydsSettings.SectionName));

var jwtSettings = builder.Configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>() ?? new JwtSettings();
var lloydsSettings = builder.Configuration.GetSection(LloydsSettings.SectionName).Get<LloydsSettings>() ?? new LloydsSettings();

// MVC + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfiguredSwaggerGen();

// JWT authentication (own API auth, not Lloyds OAuth)
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();

// HttpClient factory clients used by the Lloyds class library. Lloyds' gateway requires mutual TLS (see
// Certificates/README.md) on both the token endpoint and the bilateral channel APIs, so the same client
// certificate is attached to both named clients.
// TODO: dummy-tls-cert.pfx is a self-signed placeholder — replace with the real Lloyds-issued TLS certificate
// before this can actually reach Lloyds' gateway (see Certificates/README.md).
static void ConfigureMutualTls(HttpClientHandler handler, LloydsSettings settings)
{
    var clientCertificate = CertificateHelper.TryLoad(settings.TlsCertificatePath, settings.TlsCertificatePassword);
    if (clientCertificate is not null)
    {
        handler.ClientCertificateOptions = ClientCertificateOption.Manual;
        handler.ClientCertificates.Add(clientCertificate);
    }
}

builder.Services.AddHttpClient("LloydsClient", client =>
{
    client.BaseAddress = new Uri(lloydsSettings.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(lloydsSettings.TimeoutSeconds);
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    var handler = new HttpClientHandler();
    ConfigureMutualTls(handler, lloydsSettings);
    return handler;
});
builder.Services.AddHttpClient("LloydsTokenClient", client =>
{
    client.Timeout = TimeSpan.FromSeconds(lloydsSettings.TimeoutSeconds);
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    var handler = new HttpClientHandler();
    ConfigureMutualTls(handler, lloydsSettings);
    return handler;
});

// Lloyds class library services
builder.Services.AddSingleton<ITokenHelper, TokenHelper>();
builder.Services.AddSingleton<IJwsSigner, JwsSigner>();
builder.Services.AddScoped<IHttpHelper, HttpHelper>();

// Module services (Account, Payment, Reporting, Token/OAuth)
builder.Services.AddOAuthModule();
builder.Services.AddAccountManagementModule();
builder.Services.AddPaymentModuleA();
builder.Services.AddPaymentModuleB();
builder.Services.AddReportingModuleA();
builder.Services.AddReportingModuleB();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
