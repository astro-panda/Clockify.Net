using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Users;
using Clockify.Tests.Helpers;
using Clockify.Tests.Setup;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests
{
    public class UserTests
    {
        private readonly ClockifyClient _client;
        private string _workspaceId;

        public UserTests()
        {
            _client = new ClockifyClient(string.Empty);
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
            _workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");
        }

        // TODO Uncomment when Clockify add deleting workspaces again

        //[OneTimeTearDown]
        //public async Task Cleanup()
        //{
	       // var currentUser = await _client.GetCurrentUserAsync();
	       // var changeResponse =
		      //  await _client.SetActiveWorkspaceFor(currentUser.Data.Id, DefaultWorkspaceFixture.DefaultWorkspaceId);
	       // changeResponse.IsSuccessful.Should().BeTrue();
        //    var workspaceResponse = await _client.DeleteWorkspaceAsync(_workspaceId);
        //    workspaceResponse.IsSuccessful.Should().BeTrue();
        //}

        [Test]
        public async Task GetCurrentUser_ShouldReturnCurrentUser()
        {
            var response = await _client.GetCurrentUserAsync();
            response.IsSuccessful.Should().BeTrue();
            response.Data.Should().NotBeNull();
        }

        [Test]
        public async Task GetCurrentUser_WrongApiKey_ShouldReturnCurrentUser()
        {
            var response = await new ClockifyClient("wrong_key").GetCurrentUserAsync();
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Test]
        public async Task FindAllUsersOnWorkspace_GoodWorkspace_ShouldReturnCurrentUsers()
        {
            var response = await _client.FindAllUsersOnWorkspaceAsync(_workspaceId);
            response.IsSuccessful.Should().BeTrue();
            response.Data.Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Only shows different results in comparsion to (FindAllUsersOnWorkspace_GoodWorkspace_ShouldReturnCurrentUsers)
        /// if more han 50 users are available in clockify
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task FindAllUsersOnWorkspace_GoodWorkspace_ShouldReturnCurrentUsersWithExtendedPageSize()
        {
            var maxPageSize = 5000;
            var response = await _client.FindAllUsersOnWorkspaceAsync(_workspaceId,1,maxPageSize);
            response.IsSuccessful.Should().BeTrue();
            response.Data.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task FilterWorkspaceUsers_ShouldReturnAllUsersOnWorkspace()
        {
            // Create project to be found
            await using var projectSetup = new ProjectSetup(_client, _workspaceId);
            var projectResponse = await projectSetup.SetupAsync();
            var projectId = projectResponse.Id;

            var userResponse = await _client.GetCurrentUserAsync();
            userResponse.IsSuccessful.Should().BeTrue();


            var request = new WorkspaceUsersRequest()
            {
                Email = userResponse.Data.Email,
                IncludeRoles = true,
                Memberships = "ALL",
                Name = userResponse.Data.Name,
                Page = 1,
                PageSize = 50,
                ProjectId = projectId,
                Roles = new List<RoleType>() { RoleType.WORKSPACE_ADMIN, RoleType.OWNER, RoleType.TEAM_MANAGER, RoleType.PROJECT_MANAGER },
                SortColumn = SortColumnType.NAME,
                SortOrder = Net.Models.Reports.SortOrderType.ASCENDING,
                Status = StatusType.ACTIVE
            };

            var response = await _client.FilterWorkspaceUsers(_workspaceId, request);

            response.IsSuccessful.Should().BeTrue();
            response.Data.Should().NotBeNullOrEmpty();
        }
    }
}