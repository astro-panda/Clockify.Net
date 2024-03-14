using System;
using System.Net;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Workspaces;
using Clockify.Tests.Helpers;
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
            _client = new ClockifyClient(string.Empty);
        }

        [Test]
        public async Task GetWorkspaces_ShouldReturnWorkspaceDtoList()
        {
            var response = await _client.GetWorkspacesAsync();
            response.IsSuccessful.Should().BeTrue();
            response.Data.Should().NotBeNullOrEmpty();
        }

        [Test]
        [Ignore("This will flood your workspaces.")]
        public async Task CreateWorkspace_ShouldCreateWorkspace()
        {
            var response = await _client.CreateWorkspaceAsync(new WorkspaceRequest() {Name = "CreateWorkspaceTest " + Guid.NewGuid()});
            response.IsSuccessful.Should().BeTrue();

            // Cleanup

            // TODO Uncomment when Clockify add deleting workspaces again
            // var id = response.Data.Id;
            //var currentUser = await _client.GetCurrentUserAsync();
            //var changeWorkspaceResponse =
                  // await _client.SetActiveWorkspaceFor(currentUser.Data.Id, DefaultWorkspaceFixture.DefaultWorkspaceId);
            //changeWorkspaceResponse.IsSuccessful.Should().BeTrue();
            // var del = await _client.DeleteWorkspaceAsync(id);
            //
            // del.IsSuccessful.Should().BeTrue();
        }

        /// <summary>
        /// The example.com domain was used here because it was created for
        /// this purpose. See https://en.wikipedia.org/wiki/Example.com.
        /// </summary>
        /// <returns></returns>
        [Test]
        [Ignore("Require paid plan")]
        public async Task AddUserToWorkspace_ShouldReturnWorkspaceSettings()
        {
            string _workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");

            var request = new WorkspaceAddUserRequest
            {
                Email = Guid.NewGuid() + "@example.com",
            };

            var response = await _client.AddWorkspaceUser(_workspaceId, request);
            response.IsSuccessful.Should().BeTrue(response.Content);
        }
    }
}