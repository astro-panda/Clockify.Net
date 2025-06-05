using Microsoft.Extensions.Configuration;

namespace Clockify.Net;

/// <summary>
/// Constants used within the Clockify.Net SDK
/// </summary>
public class Constants
{
    /// <summary>
    /// The base URL of the core API
    /// </summary>
    public const string ApiUrl = "https://api.clockify.me/api/v1";

    /// <summary>
    /// The base URL of the Experimental API
    /// </summary>
    public const string ExperimentalApiUrl = "https://api.clockify.me/api/";

    /// <summary>
    /// The base URL of the Reports API
    /// </summary>
    public const string ReportsApiUrl = "https://reports.api.clockify.me/v1";

    /// <summary>
    /// The name of the API Key header for authenticating requests against Clockify APIs
    /// </summary>
    public const string ApiKeyHeaderName = "X-Api-Key";

    /// <summary>
    /// The name of the environment variable for the Clockify API Key value
    /// </summary>
    public const string ApiKeyVariableName = "CAPI_KEY";

    /// <summary>
    /// The configuration key for <see cref="IConfiguration"/> access of the API Key value
    /// </summary>
    public const string ApiKeyConfigurationKey = "Clockify:ApiKey";

    /// <summary>
    /// The name of the core Clockify HTTP client
    /// </summary>
    public const string ClockifyClientName = "Clockify";

    /// <summary>
    /// The name of the Experimental Clockify HTTP client
    /// </summary>
    public const string ExperimentalClientName = "ClockifyExperimental";

    /// <summary>
    /// The name of the Reports Clockify HTTP client
    /// </summary>
    public const string ReportsClientName = "ClockifyReports";
}
