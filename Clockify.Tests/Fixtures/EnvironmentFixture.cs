using System;
using NUnit.Framework;

namespace Clockify.Tests.Fixtures; 

public class EnvironmentFixture
{
    private const string CapiKeyName = "CAPI_KEY";

    public static void Setup()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(CapiKeyName)))
        {
            SetCapiKeyFromRunSettings();
        }
    }

    public static void TearDown()
    {
        Environment.SetEnvironmentVariable(CapiKeyName, null);
    }

    private static void SetCapiKeyFromRunSettings()
    {
        var capiKey = TestContext.Parameters[CapiKeyName];
        if (!string.IsNullOrEmpty(capiKey))
            Environment.SetEnvironmentVariable(CapiKeyName, capiKey);
        else
            TestContext.Out.WriteLine($"{CapiKeyName} environment was null or empty in .runsettings");
    }
}