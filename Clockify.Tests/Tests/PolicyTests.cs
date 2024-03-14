using System;
using System.Linq;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models;
using Clockify.Net.Models.Enums;
using Clockify.Net.Models.Policies;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests;

// TODO: Implement negative test cases
/// <summary>
///   These tests require a Workspace with at least a standard subscription to pass!
/// </summary>
[Ignore("Need a Clockify Premium plan")]
public class PolicyTests
{
	private readonly ClockifyClient _client;
	private string _firstUserId;
	private string _workspaceId;

	public PolicyTests()
	{
		_client = new ClockifyClient(string.Empty);
	}

	[OneTimeSetUp]
	public async Task Setup()
	{
		_workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");
		_firstUserId = await SetupHelper.FindFirstUserIdInWorkspaceAsync(_client, _workspaceId);
	}
	
	private PolicyRequest CreatePolicyRequest()
	{
		return new PolicyRequest(new Approve(),
			"Test policy " + Guid.NewGuid(),
			TimeUnitEnum.DAYS,
			users: new ContainsFilter
			{
				Ids = new[] {_firstUserId}
			});
	}
	
	[Test]
	public async Task CreateTimeOffPolicyAsync_ShouldCreateTimeOffPolicyAndReturnPolicyDto()
	{
		// assign
		var policyRequest = CreatePolicyRequest();

		// act
		var result = await _client.CreateTimeOffPolicyAsync(_workspaceId, policyRequest);

		// assert
		result.IsSuccessful.Should().BeTrue();
		result.Data.Should().NotBeNull();

		// cleanup
		await _client.ArchiveAndDeletePolicyAsync(_workspaceId, result.Data.Id);
	}

	[Test]
	public async Task DeletePolicyAsync_ShouldDeleteTimeOffPolicy()
	{
		// assign
		var policyRequest = CreatePolicyRequest();
		var createResult = await _client.CreateTimeOffPolicyAsync(_workspaceId, policyRequest);

		// act
		var result = await _client.ArchiveAndDeletePolicyAsync(_workspaceId, createResult.Data.Id);

		// assert
		result.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task GetPoliciesAsync_ShouldReturnArrayOfPolicyDto()
	{
		// assign
		var policyRequest = CreatePolicyRequest();
		var createResult = await _client.CreateTimeOffPolicyAsync(_workspaceId, policyRequest);

		// act
		var result = await _client.GetPoliciesAsync(_workspaceId);

		// assert
		result.IsSuccessful.Should().BeTrue();
		result.Data.Count().Should().BeGreaterOrEqualTo(1);
		
		// cleanup
		await _client.ArchiveAndDeletePolicyAsync(_workspaceId, createResult.Data.Id);
	}

	[Test]
	public async Task GetPolicyAsync_ShouldReturnPolicyDto()
	{
		// assign
		var policyRequest = CreatePolicyRequest();
		var createResult = await _client.CreateTimeOffPolicyAsync(_workspaceId, policyRequest);

		// act
		var result = await _client.GetPolicyAsync(_workspaceId, createResult.Data.Id);

		// assert
		result.IsSuccessful.Should().BeTrue();
		result.Data.Should().NotBeNull();
		result.Data.Should().BeEquivalentTo(createResult.Data);
		
		// cleanup
		await _client.ArchiveAndDeletePolicyAsync(_workspaceId, createResult.Data.Id);
	}

	[Test]
	public async Task ChangePolicyStatusAsync_ShouldChangeStatusAndReturnPolicyDto()
	{
		// assign
		var policyRequest = CreatePolicyRequest();
		var createResult = await _client.CreateTimeOffPolicyAsync(_workspaceId, policyRequest);
		var changePolicyStatusRequest = new ChangePolicyStatusRequest(StatusEnum.ARCHIVED);

		// act
		var result = await _client.ChangePolicyStatusAsync(_workspaceId, createResult.Data.Id, changePolicyStatusRequest);

		// assert
		result.IsSuccessful.Should().BeTrue();
		result.Data.Should().NotBeNull();
		result.Data.Archived.Should().BeTrue();
		
		// cleanup
		await _client.ArchiveAndDeletePolicyAsync(_workspaceId, createResult.Data.Id);
	}
	
	[Test]
	public async Task DeletePolicyAsync_ShouldDeletePolicy()
	{
		// assign
		var policyRequest = CreatePolicyRequest();
		var createResult = await _client.CreateTimeOffPolicyAsync(_workspaceId, policyRequest);
		var changePolicyStatusRequest = new ChangePolicyStatusRequest(StatusEnum.ARCHIVED);
		
		await _client.ChangePolicyStatusAsync(_workspaceId, createResult.Data.Id, changePolicyStatusRequest);

		// act
		var result = await _client.DeletePolicyAsync(_workspaceId, createResult.Data.Id);

		// assert
		result.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task UpdatePolicyAsync_ShouldUpdatePolicyAndReturnUpdatedPolicyDto()
	{
		// assign
		var policyRequest = CreatePolicyRequest();
		var createResult = await _client.CreateTimeOffPolicyAsync(_workspaceId, policyRequest);
		var updatePolicyRequest = new PolicyRequest
		{
			AllowHalfDay = createResult.Data.AllowHalfDay,
			AllowNegativeBalance = createResult.Data.AllowNegativeBalance,
			Approve = new Approve(),
			Archived = createResult.Data.Archived,
			EveryoneIncludingNew = createResult.Data.EveryoneIncludingNew,
			Name = "Test policy " + Guid.NewGuid(),
			UserGroups = new ContainsFilter
			{
				Ids = createResult.Data.UserGroupIds,
				Status = StatusEnum.ALL
			},
			Users = new ContainsFilter
			{
				Ids = createResult.Data.UserIds
			}
		};

		// act
		var result = await _client.UpdatePolicyAsync(_workspaceId, createResult.Data.Id, updatePolicyRequest);

		// assert
		result.IsSuccessful.Should().BeTrue();
		result.Data.Should().NotBeNull();
		result.Data.Name.Should().BeEquivalentTo(updatePolicyRequest.Name);
		
		// cleanup
		await _client.ArchiveAndDeletePolicyAsync(_workspaceId, createResult.Data.Id);
	}
}