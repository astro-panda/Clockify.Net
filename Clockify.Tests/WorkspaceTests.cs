using System.Threading.Tasks;
using Clockify.Net;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests {
	public class WorkspaceTests {
		private readonly ClockifyClient _client;

		public WorkspaceTests() {
			_client = new ClockifyClient();
		}

		[Test]
		public async Task GetWorkspaces_ShouldReturnWorkspaceDtoList() {
			var workspaces = await _client.GetWorkspaces();
			workspaces.Should().NotBeNullOrEmpty();
		}
	}
}