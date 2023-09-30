using Clockify.Net;
using Clockify.Net.Clients;
using Clockify.Net.Exceptions;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions for dynamically configuration the Clockify clients.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Clockify Client to the Service Collection
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    /// <exception cref="InvalidClockifyConfigurationException"></exception>
    public static IServiceCollection AddClockifyClient(this IServiceCollection services)
    {
        var sp = services.BuildServiceProvider();
        var config = sp.GetRequiredService<IConfiguration>();

        string apiKey = config.GetValue<string>(Constants.ApiKeyConfigurationKey) ?? string.Empty;
        string legacyApiKeyVariable = Environment.GetEnvironmentVariable(Constants.ApiKeyVariableName);

        string finalApiKey = string.IsNullOrWhiteSpace(apiKey) ? legacyApiKeyVariable : apiKey;

        if (string.IsNullOrWhiteSpace(finalApiKey))
            throw new InvalidClockifyConfigurationException($"Cannot a configuration value for the Environment Variable {Constants.ApiKeyVariableName} or the config key {Constants.ApiKeyConfigurationKey}");


        services.AddTransient<IClockifyClient, ClockifyClient>();


        services.AddHttpClient<IClockifyExperimentalClient>(Constants.ExperimentalClientName, httpClient =>
        {
            httpClient.BaseAddress = new Uri(Constants.ExperimentalApiUrl);
            httpClient.DefaultRequestHeaders.Add(Constants.ApiKeyHeaderName, finalApiKey);
        });

        services.AddHttpClient<IClockifyReportsClient>(Constants.ReportsClientName, httpClient =>
        {
            httpClient.BaseAddress = new Uri(Constants.ReportsApiUrl);
            httpClient.DefaultRequestHeaders.Add(Constants.ApiKeyHeaderName, finalApiKey);
        });

        services.AddHttpClient<IClockifyPTOClient>(Constants.PTOClientName, httpClient =>
        {
            httpClient.BaseAddress = new Uri(Constants.PTOApiUrl);
            httpClient.DefaultRequestHeaders.Add(Constants.ApiKeyHeaderName, finalApiKey);
        });

        services.AddHttpClient<IClockifyClient>(Constants.ClockifyClientName, httpClient =>
        {
            httpClient.BaseAddress = new Uri(Constants.ApiUrl);
            httpClient.DefaultRequestHeaders.Add(Constants.ApiKeyHeaderName, finalApiKey);
        });

        return services;
    }
}
