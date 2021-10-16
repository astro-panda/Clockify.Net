using System.Net;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Tests.Helpers;
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
            _client = new ClockifyClient();
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
    }
}