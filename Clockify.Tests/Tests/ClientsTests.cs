using System;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Clients;
using Clockify.Tests.Helpers;
using Clockify.Tests.Setup;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests; 

public class ClientsTests {
	private readonly ClockifyClient _client;
	private string _workspaceId;

	public ClientsTests() {
		_client = new ClockifyClient();
	}

	[OneTimeSetUp]
	public async Task Setup() {
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
	public async Task CreateClientAsync_ShouldCreteClientAndReturnClientDto() {
		var clientRequest = new ClientRequest { Name = "Test add client " + Guid.NewGuid() };
		var createResult = await _client.CreateClientAsync(_workspaceId, clientRequest);
		createResult.IsSuccessful.Should().BeTrue();
		createResult.Data.Should().NotBeNull();

		var findResult = await _client.FindAllClientsOnWorkspaceAsync(_workspaceId);
		findResult.IsSuccessful.Should().BeTrue();
		findResult.Data.Should().ContainEquivalentOf(createResult.Data);

		// Cleanup
		var deleteClient = await _client.ArchiveAndDeleteClientAsync(_workspaceId, createResult.Data.Id);
		deleteClient.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task FindAllClientsOnWorkspaceAsync_ShouldReturnClientsList() {
		var workspaceResponse = await _client.FindAllClientsOnWorkspaceAsync(_workspaceId);
		workspaceResponse.IsSuccessful.Should().BeTrue();
	}


	/// <summary>
	/// Only shows different results in comparsion to (FindAllClientsOnWorkspaceAsync_ShouldReturnClientsList)
	/// if more han 50 clients are available in clockify
	/// </summary>
	/// <returns></returns>
	[Test]
	public async Task FindAllClientsOnWorkspaceAsync_ShouldReturnClientsListWithExtendedPageSize() {
		var maxPageSize = 5000;
		var workspaceResponse = await _client.FindAllClientsOnWorkspaceAsync(_workspaceId, 1, maxPageSize);
		workspaceResponse.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task UpdateClientNameOnWorkspace_ShouldReturnClientUpdateDto() {
		await using var setup = new ClientSetup(_client, _workspaceId);
		var clientDto = await setup.SetupAsync();

		string updatedClientName = "Test update client " + Guid.NewGuid();

		var updateClientNameRequest = new ClientName { Name = updatedClientName };
		var updateClientNameResponse =
			await _client.UpdateClientNameAsync(_workspaceId, clientDto.Id, updateClientNameRequest);
		updateClientNameResponse.IsSuccessful.Should().BeTrue();
		updateClientNameResponse.Data.Should().NotBeNull();
		updateClientNameResponse.Data.Name.Should().Match(updatedClientName);
	}
		
	[Test]
	public async Task UpdateClient_ShouldReturnClientUpdateDto() {
		await using var setup = new ClientSetup(_client, _workspaceId);
		var clientDto = await setup.SetupAsync();

		string updatedClientName = "Test update client " + Guid.NewGuid();

		var updateClientRequest = new ClientUpdateRequest() 
		{
			Name = updatedClientName, 
			Note = "Update note " + Guid.NewGuid(), 
			Archived = true
		};
		var updateClientResponse =
			await _client.UpdateClientAsync(_workspaceId, clientDto.Id, updateClientRequest);
		updateClientResponse.IsSuccessful.Should().BeTrue();
		updateClientResponse.Data.Should().NotBeNull();
		updateClientResponse.Data.Name.Should().Be(updateClientRequest.Name);
		updateClientResponse.Data.Note.Should().Be(updateClientRequest.Note);
		updateClientResponse.Data.Archived.Should().Be(updateClientRequest.Archived);
	}

	[Test]
	public async Task DeleteClientOnWorkspace_ShouldDeleteClient() {
		// Setup
		await using var setup = new ClientSetup(_client, _workspaceId);
		var clientDto = await setup.SetupAsync();
		var updateClientRequest = new ClientUpdateRequest() 
		{
			Name = clientDto.Name, 
			Archived = true
		};
		var updateClientResponse =
			await _client.UpdateClientAsync(_workspaceId, clientDto.Id, updateClientRequest);
			
		var deleteClientResponse = await _client.DeleteClientAsync(_workspaceId, clientDto.Id);
		deleteClientResponse.IsSuccessful.Should().BeTrue();
	}
}