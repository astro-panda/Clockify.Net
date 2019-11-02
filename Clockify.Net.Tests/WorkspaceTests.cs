using System;
using FluentAssertions;
using Xunit;

namespace Clockify.Net.Tests {
	public class WorkspaceTests {

		private readonly ClockifyClient _client;

		public WorkspaceTests() {
			_client = new ClockifyClient("asda");
		}

		[Fact]
		public async void GetWorkspaces_ShouldReturnWorkspaceDtoList() {
			var workspaces = await _client.GetWorkspaces();
			workspaces.Should().NotBeNullOrEmpty();
		}
	}
}