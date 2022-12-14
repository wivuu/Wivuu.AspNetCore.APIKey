using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Wivuu.AspNetCore.APIKey;

public class DataProtectedAPIKeyOptions<TDataProtectionKey> : AuthenticationSchemeOptions
    where TDataProtectionKey : IDataProtectedKey
{
    /// <summary>
    /// Scheme used
    /// </summary>
    public string Scheme { get; set; } = "x-api-key";

    /// <summary>
    /// Provides isolated purpose between different usages using the same key
    /// </summary>
    public string UsagePurpose { get; set; } = "x-api-key";

    /// <summary>
    /// The duration for which to cache successfully authenticated tokens
    /// </summary>
    public TimeSpan? CacheDurationSuccess { get; set; }

    /// <summary>
    /// The duration for which to cache failed authentication attempts, default 10 seconds
    /// </summary>
    public TimeSpan CacheDurationFailure { get; set; } = TimeSpan.FromSeconds(10);

    /// <summary>
    /// Callback to validate the key, if necessary and generate a ClaimsPrincipal or fail the transaction
    /// 
    /// If not provided, a default authenticated principal will be generated
    /// </summary>
    public Func<IServiceProvider, TDataProtectionKey, Task<AuthenticateResult>>? BuildAuthenticationResponseAsync { get; set; } = null;

    /// <summary>
    /// Implement to provide mechanism for retrieving the key from the request
    /// </summary>
    public Func<HttpRequest, string?>? GetKeyFromRequest { get; set; } = null;
}