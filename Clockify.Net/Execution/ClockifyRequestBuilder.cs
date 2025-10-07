
using System.Net.Http.Headers;

namespace Clockify.Net;

public class ClockifyRequestBuilder
{
    public ClockifyRequestBuilder() { }

    public string BaseHost { get; private set; } = Constants.ApiHost;

    public string Subdomain { get; private set; } = Constants.CoreApiSubdomain;

    public string WorkspaceId { get; private set; } = string.Empty;

    public string Version { get; private set; } = "v1";

    public string Path { get; private set; } = string.Empty;

    public ClockifyRequestBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public ClockifyRequestBuilder WithWorkspaceId(string workspaceId)
    {
        WorkspaceId = workspaceId;
        return this;
    }

    public ClockifyRequestBuilder WithSubdomain(string subdomain)
    {
        Subdomain = subdomain;
        return this;
    }

    public ClockifyRequestBuilder PrependSubdomain(string newSubdomain)
    {
        WithSubdomain($"{newSubdomain}.{Subdomain}");
        return this;
    }

    public ClockifyRequestBuilder UseMainGlobalEndpoint()
    {
        BaseHost = Constants.ApiUrl;
        return this;
    }

    public ClockifyRequestBuilder UseMainRegionalEndpoint(string region)
    {
        WithSubdomain(region);
        return this;
    }

    public ClockifyRequestBuilder UsePtoEndpoint()
    {
        WithSubdomain(Constants.PtoSubdomain);
        return this;
    }

    public ClockifyRequestBuilder UseReportsEndpoint()
    {
        WithSubdomain(Constants.ReportsSubdomain);
        return this;
    }
}