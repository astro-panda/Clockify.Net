using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Workspaces;
using Clockify.Tests.Fixtures;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests
{
	[TestFixture]
    public class WorkspaceTests
    {
        private ClockifyClient _client;

        [OneTimeSetUp]
        public void Setup()
        {
            _client = new ClockifyClient();
        }

        [Test]
        public async Task GetWorkspaces_ShouldReturnWorkspaceDtoList()
        {
            var response = await _client.GetWorkspacesAsync();
            response.IsSuccessful.Should().BeTrue();
            response.Data.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task CreateWorkspace_ShouldCreateWorkspace()
        {
            var response = await _client.CreateWorkspaceAsync(new WorkspaceRequest() {Name = "CreateWorkspaceTest"});
            response.IsSuccessful.Should().BeTrue();

            // Cleanup
            var id = response.Data.Id;

            var currentUser = await _client.GetCurrentUserAsync();
            var changeWorkspaceResponse =
	            await _client.SetActiveWorkspaceFor(currentUser.Data.Id, DefaultWorkspaceFixture.DefaultWorkspaceId);
            changeWorkspaceResponse.IsSuccessful.Should().BeTrue();
            var del = await _client.DeleteWorkspaceAsync(id);

            del.IsSuccessful.Should().BeTrue();
        }
    }
}