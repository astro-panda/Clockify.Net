using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Clients;
using Clockify.Net.Models.Workspaces;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests
{
    public class ClientsTests
    {
        private readonly ClockifyClient _client;
        private string _workspaceId;

        public ClientsTests()
        {
            _client = new ClockifyClient();
        }

        [SetUp]
        public async Task Setup()
        {
            var workspaceResponse =
                await _client.CreateWorkspaceAsync(new WorkspaceRequest {Name = "ClientTestWorkspace"});
            workspaceResponse.IsSuccessful.Should().BeTrue();
            _workspaceId = workspaceResponse.Data.Id;
        }

        [TearDown]
        public async Task Cleanup()
        {
            var workspaceResponse = await _client.DeleteWorkspaceAsync(_workspaceId);
            workspaceResponse.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public async Task CreateClientAsync_ShouldCreteClientAndReturnClientDto()
        {
            var clientRequest = new ClientRequest {Name = "Test add client"};
            var createResult = await _client.CreateClientAsync(_workspaceId, clientRequest);
            createResult.IsSuccessful.Should().BeTrue();
            createResult.Data.Should().NotBeNull();

            var findResult = await _client.FindAllClientsOnWorkspaceAsync(_workspaceId);
            findResult.IsSuccessful.Should().BeTrue();
            findResult.Data.Should().ContainEquivalentOf(createResult.Data);
        }

        [Test]
        public async Task FindAllClientsOnWorkspaceAsync_ShouldReturnClientsList()
        {
            var workspaceResponse = await _client.FindAllClientsOnWorkspaceAsync(_workspaceId);
            workspaceResponse.IsSuccessful.Should().BeTrue();
        }
    }
}