using System;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Clients;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests
{
    public class ClientsTests
    {
        private readonly ClockifyClient _client;
        private string _workspaceId;

        public ClientsTests()
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
        //public async Task Cleanup() {
	       // var currentUser = await _client.GetCurrentUserAsync();
	       // var changeResponse =
		      //  await _client.SetActiveWorkspaceFor(currentUser.Data.Id, DefaultWorkspaceFixture.DefaultWorkspaceId);
	       // changeResponse.IsSuccessful.Should().BeTrue();
        //    var workspaceResponse = await _client.DeleteWorkspaceAsync(_workspaceId);
        //    workspaceResponse.IsSuccessful.Should().BeTrue();
        //}

        [Test]
        public async Task CreateClientAsync_ShouldCreteClientAndReturnClientDto()
        {
            var clientRequest = new ClientRequest {Name = "Test add client " + Guid.NewGuid()};
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


        /// <summary>
        /// Only shows different results in comparsion to (FindAllClientsOnWorkspaceAsync_ShouldReturnClientsList)
        /// if more han 50 clients are available in clockify
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task FindAllClientsOnWorkspaceAsync_ShouldReturnClientsListWithExtendedPageSize()
        {
            var workspaceResponse = await _client.FindAllClientsOnWorkspaceAsync(_workspaceId,1,10000);
            workspaceResponse.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public async Task UpdateClientNameOnWorkspace_ShouldReturnClientUpdateDto()
        {
            var clientRequest = new ClientRequest { Name = "Test add client " + Guid.NewGuid() };
            var createResult = await _client.CreateClientAsync(_workspaceId, clientRequest);
            createResult.IsSuccessful.Should().BeTrue();
            createResult.Data.Should().NotBeNull();

            string updatedClientName = "Test update client " + Guid.NewGuid();

            var updateClientNameRequest = new ClientName { Name = updatedClientName };
            var updateClientNameResponse = await _client.UpdateClientNameAsync(_workspaceId, createResult.Data.Id, updateClientNameRequest);
            updateClientNameResponse.IsSuccessful.Should().BeTrue();
            updateClientNameResponse.Data.Should().NotBeNull();
            updateClientNameResponse.Data.Name.Should().Match(updatedClientName);
        }
    }
}