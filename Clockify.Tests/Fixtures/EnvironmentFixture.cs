using System;
using Clockify.Net;
using NUnit.Framework;

namespace Clockify.Tests.Fixtures; 

public class EnvironmentFixture
{
    public static void Setup()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ClockifyClient2.ApiKeyVariableName)))
        {
            SetCapiKeyFromRunSettings();
        }
    }

    public static void TearDown()
    {
        Environment.SetEnvironmentVariable(ClockifyClient2.ApiKeyVariableName, null);
    }

    private static void SetCapiKeyFromRunSettings()
    {
        var capiKey = TestContext.Parameters[ClockifyClient2.ApiKeyVariableName];
        if (!string.IsNullOrEmpty(capiKey))
            Environment.SetEnvironmentVariable(ClockifyClient2.ApiKeyVariableName, capiKey);
        else
            TestContext.Out.WriteLine($"{ClockifyClient2.ApiKeyVariableName} environment was null or empty in .runsettings file");
    }
}