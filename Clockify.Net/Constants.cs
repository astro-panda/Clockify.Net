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
    public const string ApiUrl = $"https://{CoreApiSubdomain}.{ApiHost}/api/v1";

    /// <summary>
    /// The host name of the core API
    /// </summary>
    public const string ApiHost = "clockify.me";

    /// <summary>
    /// The base URL of the Experimental API
    /// </summary>
    public const string ExperimentalApiUrl = "https://api.clockify.me/api/";

    /// <summary>
    /// The base URL of the Reports API
    /// </summary>
    public const string ReportsApiUrl = "https://reports.api.clockify.me/v1";

    /// <summary>
    /// The main subdomain for the core API
    /// </summary>
    public const string CoreApiSubdomain = "api";

    /// <summary>
    /// The subdomain for the PTO endpoint
    /// </summary>
    public const string PtoSubdomain = "pto";

    /// <summary>
    /// The subdomain for the Reports endpoint
    /// </summary>
    public const string ReportsSubdomain = "reports";

    /// <summary>
    /// The name of the API Key header for authenticating requests against Clockify APIs
    /// </summary>
    public const string ApiKeyHeaderName = "X-Api-Key";

    /// <summary>
    /// The name of the Addon Token header for authenticating requests against Clockify APIs
    /// when used in an Addon context
    /// </summary>
    public const string AddonTokenHeaderName = "X-Addon-Token";

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

    /// <summary>
    /// The prefixes for the supported global regions for targeting.
    /// </summary>
    public class Regions
    {
        /// <summary>
        /// The region prefix for USA data center
        /// </summary>
        public const string USA = "use2";

        /// <summary>
        /// The region prefix for EU data center
        /// </summary>
        public const string EU = "euc1";

        /// <summary>
        /// The region prefix for UK data center
        /// </summary>
        public const string UK = "euw2";

        /// <summary>
        /// The region prefic for the Australia data center
        /// </summary>
        public const string AU = "apse2";
    }
}
