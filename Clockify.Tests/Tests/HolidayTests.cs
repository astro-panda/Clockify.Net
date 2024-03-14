using System;
using System.Linq;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models;
using Clockify.Net.Models.Holiday;
using Clockify.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

namespace Clockify.Tests.Tests;

/// <summary>
///   These tests require a Workspace with at least a standard subscription to pass!
/// </summary>
[Ignore("Need a Clockify Premium plan")]
public class HolidayTests
{
	private readonly ClockifyClient _client;
	private string _firstUserId;
	private string _workspaceId;

	public HolidayTests()
	{
		_client = new ClockifyClient(string.Empty);
    }

	[OneTimeSetUp]
	public async Task Setup()
	{
		_workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");
		_firstUserId = await SetupHelper.FindFirstUserIdInWorkspaceAsync(_client, _workspaceId);
	}

	private HolidayRequest CreateHolidayRequest()
	{
		return new HolidayRequest(new DatePeriod
			{
				StartDate = DateTime.Today,
				EndDate = DateTime.Today
			},
			"Test holiday " + Guid.NewGuid(),
			users: new ContainsFilter
			{
				Ids = new[] {_firstUserId}
			});
	}

	private HolidayRequest CreateUpdateHolidayRequest()
	{
		return new HolidayRequest(new DatePeriod
			{
				StartDate = DateTime.Today,
				EndDate = DateTime.Today
			},
			"Test holiday " + Guid.NewGuid(),
			false,
			users: new ContainsFilter
			{
				Ids = new[] {_firstUserId}
			});
	}

	[Test]
	public async Task GetHolidaysAsync_ShouldReturnHolidayList()
	{
		// assign & act
		var response = await _client.GetHolidaysAsync(_workspaceId);

		// assert
		response.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task CreateHolidayAsync_ShouldCreateHolidayAndReturnHolidayDto()
	{
		// assign
		var holidayRequest = CreateHolidayRequest();

		// act
		var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);

		// assert
		createResult.IsSuccessful.Should().BeTrue();
		createResult.Data.Should().NotBeNull();

		// cleanup
		var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);
		deleteHoliday.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task CreateHolidayAsync_WithNullDatePeriod_ShouldThrowArgumentException()
	{
		// assign
		var holidayRequest = new HolidayRequest
		{
			Name = "Test",
			DatePeriod = null
		};

		// act
		Func<Task> create = async () => await _client.CreateHolidayAsync(_workspaceId, holidayRequest);

		// assert
		await create.Should().ThrowAsync<ArgumentException>()
			.WithMessage($"Value cannot be null. (Parameter '{nameof(HolidayRequest.DatePeriod)}')");
	}

	[Test]
	public async Task CreateHolidayAsync_WithNullName_ShouldThrowArgumentException()
	{
		// assign
		var holidayRequest = new HolidayRequest
		{
			Name = null,
			DatePeriod = new DatePeriod()
		};

		// act
		Func<Task> create = async () => await _client.CreateHolidayAsync(_workspaceId, holidayRequest);

		// assert
		await create.Should().ThrowAsync<ArgumentException>()
			.WithMessage($"Value cannot be null. (Parameter '{nameof(HolidayRequest.Name)}')");
	}

	[Test]
	public async Task GetHolidayInSpecificPeriodAsync_ShouldReturnHoliday()
	{
		// assign
		var firstUser = await _client.FindAllUsersOnWorkspaceAsync(_workspaceId);
		var createHolidayRequest = CreateHolidayRequest();
		var createResult = await _client.CreateHolidayAsync(_workspaceId, createHolidayRequest);
		createResult.IsSuccessful.Should().BeTrue();
		createResult.Data.Should().NotBeNull();
		var holidayRequest = new GetHolidaysRequest
		{
			AssignedTo = firstUser.Data.First().ID,
			Start = DateTime.Today.AsUtc().AddDays(-1),
			End = DateTime.Today.AsUtc().AddDays(1)
		};

		// act
		var response = await _client.GetHolidayInSpecificPeriodAsync(_workspaceId, holidayRequest);

		// assert
		response.IsSuccessful.Should().BeTrue();

		// cleanup
		var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);
		deleteHoliday.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task GetHolidayInSpecificPeriodAsync_WithAssignedToNull_ShouldThrowArgumentException()
	{
		// assign
		var holidayRequest = new GetHolidaysRequest
		{
			AssignedTo = null,
			Start = DateTime.Today,
			End = DateTime.Today
		};

		// act
		Func<Task> create = async () => await _client.GetHolidayInSpecificPeriodAsync(_workspaceId, holidayRequest);

		// assert
		await create.Should().ThrowAsync<ArgumentException>()
			.WithMessage($"Value cannot be null. (Parameter '{nameof(GetHolidaysRequest.AssignedTo)}')");
	}

	[Test]
	public async Task GetHolidayInSpecificPeriodAsync_WithStartNull_ShouldThrowArgumentException()
	{
		// assign
		var holidayRequest = new GetHolidaysRequest
		{
			AssignedTo = "test",
			Start = null,
			End = DateTime.Today
		};

		// act
		Func<Task> create = async () => await _client.GetHolidayInSpecificPeriodAsync(_workspaceId, holidayRequest);

		// assert
		await create.Should().ThrowAsync<ArgumentException>()
			.WithMessage($"Value cannot be null. (Parameter '{nameof(GetHolidaysRequest.Start)}')");
	}

	[Test]
	public async Task GetHolidayInSpecificPeriodAsync_WithEndNull_ShouldThrowArgumentException()
	{
		// assign
		var holidayRequest = new GetHolidaysRequest
		{
			AssignedTo = "test",
			Start = DateTime.Today,
			End = null
		};

		// act
		Func<Task> create = async () => await _client.GetHolidayInSpecificPeriodAsync(_workspaceId, holidayRequest);

		// assert
		await create.Should().ThrowAsync<ArgumentException>()
			.WithMessage($"Value cannot be null. (Parameter '{nameof(GetHolidaysRequest.End)}')");
	}

	[Test]
	public async Task DeleteHolidayAsync_ShouldDeleteHoliday()
	{
		// assign
		var holidayRequest = CreateHolidayRequest();
		var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);

		// act
		var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);

		// assert
		deleteHoliday.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task UpdateHolidayAsync_ShouldUpdateHoliday()
	{
		// assign
		var holidayRequest = CreateHolidayRequest();
		var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
		var updateRequest = CreateUpdateHolidayRequest();
		updateRequest.Name = "Upd holiday " + Guid.NewGuid();

		// act
		var updateResult = await _client.UpdateHolidayAsync(_workspaceId, createResult.Data.Id, updateRequest);

		// assert
		updateResult.IsSuccessful.Should().BeTrue();

		// cleanup
		var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);
		deleteHoliday.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task UpdateHolidayAsync_WithDatePeriodNull_ShouldThrowArgumentException()
	{
		// assign
		var holidayRequest = CreateHolidayRequest();
		var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
		var updateRequest = CreateUpdateHolidayRequest();
		updateRequest.DatePeriod = null;

		// act
		var update = async () => await _client.UpdateHolidayAsync(_workspaceId, createResult.Data.Id, updateRequest);

		// assert
		await update.Should().ThrowAsync<ArgumentException>()
			.WithMessage($"Value cannot be null. (Parameter '{nameof(HolidayRequest.DatePeriod)}')");

		// cleanup
		var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);
		deleteHoliday.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task UpdateHolidayAsync_WithDatePeriodEndDateNull_ShouldThrowArgumentException()
	{
		// assign
		var holidayRequest = CreateHolidayRequest();
		var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
		var updateRequest = CreateUpdateHolidayRequest();
		updateRequest.DatePeriod.EndDate = null;

		// act
		var update = async () => await _client.UpdateHolidayAsync(_workspaceId, createResult.Data.Id, updateRequest);

		// assert
		await update.Should().ThrowAsync<ArgumentException>()
			.WithMessage($"Value cannot be null. (Parameter '{nameof(HolidayRequest.DatePeriod.EndDate)}')");

		// cleanup
		var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);
		deleteHoliday.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task UpdateHolidayAsync_WithDatePeriodStartDateNull_ShouldThrowArgumentException()
	{
		// assign
		var holidayRequest = CreateHolidayRequest();
		var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
		var updateRequest = CreateUpdateHolidayRequest();
		updateRequest.DatePeriod.StartDate = null;

		// act
		var update = async () => await _client.UpdateHolidayAsync(_workspaceId, createResult.Data.Id, updateRequest);

		// assert
		await update.Should().ThrowAsync<ArgumentException>()
			.WithMessage($"Value cannot be null. (Parameter '{nameof(HolidayRequest.DatePeriod.StartDate)}')");

		// cleanup
		var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);
		deleteHoliday.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task UpdateHolidayAsync_WithNameNull_ShouldThrowArgumentException()
	{
		// assign
		var holidayRequest = CreateHolidayRequest();
		var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
		var updateRequest = CreateUpdateHolidayRequest();
		updateRequest.Name = null;

		// act
		var update = async () => await _client.UpdateHolidayAsync(_workspaceId, createResult.Data.Id, updateRequest);

		// assert
		await update.Should().ThrowAsync<ArgumentException>()
			.WithMessage($"Value cannot be null. (Parameter '{nameof(HolidayRequest.Name)}')");

		// cleanup
		var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);
		deleteHoliday.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public async Task UpdateHolidayAsync_WithOccursAnnuallyNull_ShouldThrowArgumentException()
	{
		// assign
		var holidayRequest = CreateHolidayRequest();
		var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
		var updateRequest = CreateUpdateHolidayRequest();
		updateRequest.OccursAnnually = null;

		// act
		var update = async () => await _client.UpdateHolidayAsync(_workspaceId, createResult.Data.Id, updateRequest);

		// assert
		await update.Should().ThrowAsync<ArgumentException>()
			.WithMessage($"Value cannot be null. (Parameter '{nameof(HolidayRequest.OccursAnnually)}')");

		// cleanup
		var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);
		deleteHoliday.IsSuccessful.Should().BeTrue();
	}
}