using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.TimeOff;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests;

// TODO: Implement test cases
/// <summary>
/// These tests require a Workspace with at least a standard subscription to pass!
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
		_policyId = await SetupHelper.CreateOrFindPolicy(_client, _workspaceId, _firstUserId, "Test policy");
	}

	[Test]
	public async Task CreateTimeOffRequestAsync_ShouldCreateTimeOffRequestAsyncAndReturnDto()
	{
		// assign
		var timeOffRequestRequest = new TimeOffRequestRequest
		{
			Note = "Test time off request",
			TimeOffPeriod = new TimeOffRequestPeriodV1Request
			{
				Period = new DatePeriod
				{
					Days = 2,
					Start = DateTime.Today,
					End = DateTime.Today.AddDays(1)
				}
			}
		};

		// act
		var result = await _client.CreateTimeOffRequestAsync(_workspaceId, _policyId, _firstUserId, timeOffRequestRequest);

		// assert
		result.IsSuccessful.Should().BeTrue();
		result.Data.Should().NotBeNull();

		// cleanup
		var deleteResult = await _client.DeleteTimeOffRequestAsync(_workspaceId, _policyId, result.Data.Id);
		deleteResult.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task GetAllTimeOffRequestsAsync_ShouldReturnAllTimeOffRequests()
	{
		// assign
		var timeOffRequestRequest = new TimeOffRequestRequest
		{
			Note = "Test time off request",
			TimeOffPeriod = new TimeOffRequestPeriodV1Request
			{
				Period = new DatePeriod
				{
					Days = 2,
					Start = DateTime.Today,
					End = DateTime.Today.AddDays(1)
				}
			}
		};
		var createResult =
			await _client.CreateTimeOffRequestAsync(_workspaceId, _policyId, _firstUserId, timeOffRequestRequest);
		var getAllTimeOffRequestsRequest = new GetAllTimeOffRequestsRequest
		{
			Statuses = new[] {TimeOffRequestStatusEnum.ALL},
			Users = new[] {_firstUserId}
		};

		// act
		var result = await _client.GetAllTimeOffRequestsAsync(_workspaceId, getAllTimeOffRequestsRequest);

		// assert
		result.StatusCode.Should().Be(HttpStatusCode.OK);
		result.Data.Should().NotBeNull();
		result.Data.Count.Should().BeGreaterOrEqualTo(1);
		result.Data.Requests.Count().Should().BeGreaterOrEqualTo(1);

		// cleanup
		var deleteResult = await _client.DeleteTimeOffRequestAsync(_workspaceId, _policyId, createResult.Data.Id);
		deleteResult.IsSuccessful.Should().BeTrue();
	}
}