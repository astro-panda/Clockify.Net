using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Workspaces;
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
			var response = await _client.GetWorkspaces();
			response.IsSuccessful.Should().BeTrue();
			response.Data.Should().NotBeNullOrEmpty();
		}

		[Test]
		public async Task CreateWorkspace_ShouldCreateWorkspace() {
			var response = await _client.CreateWorkspace(new WorkspaceRequest() { Name = "CreateWorkspaceTest" });
			response.IsSuccessful.Should().BeTrue();

			// Cleanup
			var id = response.Data.Id;
			var del = await _client.DeleteWorkspace(id);
			del.IsSuccessful.Should().BeTrue();
		}
	}
}