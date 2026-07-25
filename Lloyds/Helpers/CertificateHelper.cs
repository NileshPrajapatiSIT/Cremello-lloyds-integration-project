using System.Security.Cryptography.X509Certificates;

namespace Lloyds.Helpers;

/// <summary>Loads PFX certificates used for mutual TLS and JWS request signing against Lloyds' API gateway.</summary>
public static class CertificateHelper
{
    /// <summary>Returns null (rather than throwing) when no path is configured or the file is missing, so the
    /// app can still start with the dummy/placeholder configuration described in Certificates/README.md.</summary>
    public static X509Certificate2? TryLoad(string path, string password)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return null;
        }

        var resolvedPath = Path.IsPathRooted(path) ? path : Path.Combine(AppContext.BaseDirectory, path);

        return File.Exists(resolvedPath)
            ? new X509Certificate2(resolvedPath, password, X509KeyStorageFlags.Exportable)
            : null;
    }
}
