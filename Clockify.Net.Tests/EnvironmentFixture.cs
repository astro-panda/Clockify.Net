using System;
using Microsoft.Extensions.Configuration;

namespace Clockify.Net.Tests {
	internal class EnvironmentFixture : IDisposable {
		public EnvironmentFixture() {
			var a = TestContext.Parameters;

		}
		public void Dispose() {
			Environment.SetEnvironmentVariable("CAPI_KEY", null);
		}
	}
}