using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models;
using Clockify.Net.Models.Enums;
using Clockify.Net.Models.Policies;
using Clockify.Net.Models.TimeOff;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests;

// TODO: Implement negative test cases
/// <summary>
///   These tests require a Workspace with at least a standard subscription to pass!
/// </summary>
public class TimeOffTests
{
	private readonly ClockifyClient _client;
	private string _firstUserId;
	private string _policyId;
	private string _workspaceId;

	public TimeOffTests()
	{
		_client = new ClockifyClient();
	}

	[OneTimeSetUp]
	public async Task Setup()
	{
		_workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");
		_firstUserId = await SetupHelper.FindFirstUserIdInWorkspaceAsync(_client, _workspaceId);
		_policyId = await SetupHelper.CreateOrFindPolicy(_client, _workspaceId, _firstUserId,
			"Test policy " + Guid.NewGuid());
	}

	[OneTimeTearDown]
	public async Task TearDown()
	{
		await _client.ArchiveAndDeletePolicyAsync(_workspaceId, _policyId);
	}

	private static TimeOffRequestRequest CreateTimeOffRequestRequest()
	{
		return new TimeOffRequestRequest
		{
			Note = "Test time off request " + Guid.NewGuid(),
			TimeOffPeriod = new TimeOffRequestPeriodV1Request
			{
				Period = new PeriodV1Request
				{
					Days = 2,
					Start = DateTime.Today,
					End = DateTime.Today.AddDays(1)
				}
			}
		};
	}

	[Test]
	public async Task CreateTimeOffRequestAsync_ShouldCreateTimeOffRequestAndReturnDto()
	{
		// assign
		var timeOffRequestRequest = CreateTimeOffRequestRequest();

		// act
		var result = await _client.CreateTimeOffRequestAsync(_workspaceId, _policyId, _firstUserId, timeOffRequestRequest);

		// assert
		result.IsSuccessful.Should().BeTrue();
		result.Data.Should().NotBeNull();

		// cleanup
		await _client.DeleteTimeOffRequestAsync(_workspaceId, _policyId, result.Data.Id);
	}

	[Test]
	public async Task DeleteTimeOffRequestAsync_ShouldDeleteTimeOffRequest()
	{
		// assign
		var timeOffRequestRequest = CreateTimeOffRequestRequest();
		var createResult =
			await _client.CreateTimeOffRequestAsync(_workspaceId, _policyId, _firstUserId, timeOffRequestRequest);

		// act
		var result = await _client.DeleteTimeOffRequestAsync(_workspaceId, _policyId, createResult.Data.Id);

		// assert
		result.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task GetAllTimeOffRequestsAsync_ShouldReturnAllTimeOffRequests()
	{
		// assign
		var timeOffRequestRequest = CreateTimeOffRequestRequest();
		var createResult =
			await _client.CreateTimeOffRequestAsync(_workspaceId, _policyId, _firstUserId, timeOffRequestRequest);
		var getAllTimeOffRequestsRequest =
			new GetAllTimeOffRequestsRequest(new[] {TimeOffRequestStatusEnum.ALL}, users: new[] {_firstUserId});

		// act
		var result = await _client.GetAllTimeOffRequestsAsync(_workspaceId, getAllTimeOffRequestsRequest);

		// assert
		result.StatusCode.Should().Be(HttpStatusCode.OK);
		result.Data.Should().NotBeNull();
		result.Data.Count.Should().BeGreaterOrEqualTo(1);
		result.Data.Requests.Count().Should().BeGreaterOrEqualTo(1);

		// cleanup
		await _client.DeleteTimeOffRequestAsync(_workspaceId, _policyId, createResult.Data.Id);
	}

	[Ignore("This test needs refinement because the setup is very tricky and dependent on the API Key you provided")]
	[Test]
	public async Task CreateTimeOffRequestForDayPoliciesAsync_ShouldCreateTimeOffRequestAndReturnDto()
	{
		// assign
		// the calling user (corresponding API Key) must be allowed to request a Time Off Request
		// so here this user gets added
		const string apiKeyUserId = ""; // SET THE USER ID WHICH CORRELATES TO THE USED API KEY
		var policyUpdateRequest = new PolicyRequest(
			false,
			true,
			new Approve(),
			false,
			false,
			"Test changed " + Guid.NewGuid(),
			new ContainsFilter
			{
				Ids = Array.Empty<string>(),
				Status = StatusEnum.ALL
			},
			new ContainsFilter
			{
				Ids = new[] {_firstUserId, apiKeyUserId}
			});
		await _client.UpdatePolicyAsync(_workspaceId, _policyId, policyUpdateRequest);

		var timeOffRequestRequest = CreateTimeOffRequestRequest();

		// act
		var result =
			await _client.CreateTimeOffRequestForDayPoliciesAsync(_workspaceId, _policyId, timeOffRequestRequest);

		// assert
		result.IsSuccessful.Should().BeTrue();
		result.Data.Should().NotBeNull();

		// cleanup
		await _client.DeleteTimeOffRequestAsync(_workspaceId, _policyId, result.Data.Id);
	}

	[Test]
	public async Task ChangeTimeOffRequestStatusAsync_ShouldChangeTimeOffRequestStatusAndReturnUpdatedDto()
	{
		// assign
		var policyResponse = await _client.CreateTimeOffPolicyAsync(_workspaceId, new PolicyRequest
		{
			Name = "Test policy " + Guid.NewGuid(),
			AllowNegativeBalance = true,
			Approve = new Approve
			{
				RequiresApproval = true
			},
			TimeUnit = TimeUnitEnum.DAYS,
			Users = new ContainsFilter
			{
				Ids = new[] {_firstUserId}
			}
		});
		var timeOffRequestRequest = CreateTimeOffRequestRequest();
		var createdResult =
			await _client.CreateTimeOffRequestAsync(_workspaceId, policyResponse.Data.Id, _firstUserId,
				timeOffRequestRequest);
		var changeTimeOffRequestStatusRequest = new ChangeTimeOffRequestStatusRequest(TimeOffRequestStatusEnum.APPROVED);

		// act
		var result = await _client.ChangeTimeOffRequestStatusAsync(_workspaceId, policyResponse.Data.Id,
			createdResult.Data.Id, changeTimeOffRequestStatusRequest);

		// assert
		result.IsSuccessful.Should().BeTrue();
		result.Data.Should().NotBeNull();
		result.Data.Status.StatusType.Should().BeEquivalentTo(changeTimeOffRequestStatusRequest.Status.ToString());

		// cleanup
		await _client.DeleteTimeOffRequestAsync(_workspaceId, policyResponse.Data.Id, result.Data.Id);
		await _client.ArchiveAndDeletePolicyAsync(_workspaceId, policyResponse.Data.Id);
	}
}