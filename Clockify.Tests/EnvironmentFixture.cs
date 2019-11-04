using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Clockify.Tests {
	[SetUpFixture]
	public class EnvironmentFixture {
		private const string CapiKeyName = "CAPI_KEY";

		[OneTimeSetUp]
		public void Setup() {
			if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(CapiKeyName))) {
				SetCapiKeyFromRunSettings();
			}
		}

		[OneTimeTearDown]
		public void TearDown() {
			Environment.SetEnvironmentVariable(CapiKeyName, null);
		}

		private static void SetCapiKeyFromRunSettings() {
			var capiKey = TestContext.Parameters[CapiKeyName];
			if (!string.IsNullOrEmpty(capiKey))
				Environment.SetEnvironmentVariable(CapiKeyName, capiKey);
			else
				TestContext.Out.WriteLine($"{CapiKeyName} environment was null or empty in .runsettings");
		}

	}
}