using System;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Holiday;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests;

public class HolidayTests
{
    private readonly ClockifyClient _client;
    private string _workspaceId;

    public HolidayTests()
    {
        _client = new ClockifyClient();
    }

    [OneTimeSetUp]
    public async Task Setup()
    {
        _workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");
    }
    
    [Test]
    public async Task GetHolidaysAsync_ShouldReturnHolidayList()
    {
        var response = await _client.GetHolidaysAsync(_workspaceId);
        response.IsSuccessful.Should().BeTrue();
    }

    [Test]
    public async Task CreateHolidayAsync_ShouldCreateHolidayAndReturnHolidayDto()
    {
        var holidayRequest = new HolidayRequest
        {
            Name = "Test holiday " + Guid.NewGuid(),
            DatePeriod = new DatePeriod
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            }
        };
        var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
        createResult.IsSuccessful.Should().BeTrue();
        createResult.Data.Should().NotBeNull();

        var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);
        deleteHoliday.IsSuccessful.Should().BeTrue();
    }
    
    [Test]
    public async Task CreateHolidayAsync_WithNullDatePeriod_ShouldThrowArgumentException()
    {
        var holidayRequest = new HolidayRequest
        {
            Name = "Test",
            DatePeriod = null
        };
        Func<Task> create = async () => await _client.CreateHolidayAsync(_workspaceId, holidayRequest);

        await create.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"Value cannot be null. (Parameter '{nameof(HolidayRequest.DatePeriod)}')");
    }
        
    [Test]
    public async Task CreateHolidayAsync_WithNullName_ShouldThrowArgumentException()
    {
        var holidayRequest = new HolidayRequest
        {
            Name = null,
            DatePeriod = new DatePeriod()
        };
        Func<Task> create = async () => await _client.CreateHolidayAsync(_workspaceId, holidayRequest);

        await create.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"Value cannot be null. (Parameter '{nameof(HolidayRequest.DatePeriod)}')");
    }

    [Test]
    public async Task GetHolidayInSpecificPeriodAsync_ShouldReturnHoliday()
    {
        var holidayRequest = new GetHolidaysRequest
        {
            AssignedTo = "test",
            Start = DateTime.Today,
            End = DateTime.Today
        };
        var response = await _client.GetHolidayInSpecificPeriodAsync(_workspaceId, holidayRequest);
        response.IsSuccessful.Should().BeTrue();
    }

    [Test]
    public async Task GetHolidayInSpecificPeriodAsync_WithAssignedToNull_ShouldThrowArgumentException()
    {
        var holidayRequest = new GetHolidaysRequest
        {
            AssignedTo = null,
            Start = DateTime.Today,
            End = DateTime.Today
        };
        Func<Task> create = async () => await _client.GetHolidayInSpecificPeriodAsync(_workspaceId, holidayRequest);

        await create.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"Value cannot be null. (Parameter '{nameof(GetHolidaysRequest.AssignedTo)}')");
    }

    [Test]
    public async Task GetHolidayInSpecificPeriodAsync_WithStartNull_ShouldThrowArgumentException()
    {
        var holidayRequest = new GetHolidaysRequest
        {
            AssignedTo = "test",
            Start = null,
            End = DateTime.Today
        };
        Func<Task> create = async () => await _client.GetHolidayInSpecificPeriodAsync(_workspaceId, holidayRequest);

        await create.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"Value cannot be null. (Parameter '{nameof(GetHolidaysRequest.Start)}')");
    }

    [Test]
    public async Task GetHolidayInSpecificPeriodAsync_WithEndNull_ShouldThrowArgumentException()
    {
        var holidayRequest = new GetHolidaysRequest
        {
            AssignedTo = "test",
            Start = DateTime.Today,
            End = null
        };
        Func<Task> create = async () => await _client.GetHolidayInSpecificPeriodAsync(_workspaceId, holidayRequest);

        await create.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"Value cannot be null. (Parameter '{nameof(GetHolidaysRequest.End)}')");
    }
    
    [Test]
    public async Task DeleteHolidayAsync_ShouldDeleteHoliday()
    {
        var holidayRequest = new HolidayRequest
        {
            Name = "Test holiday " + Guid.NewGuid(),
            DatePeriod = new DatePeriod
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            }
        };
        var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
        var deleteHoliday = await _client.DeleteHolidayAsync(_workspaceId, createResult.Data.Id);
        deleteHoliday.IsSuccessful.Should().BeTrue();
    }

    [Test]
    public async Task UpdateHolidayAsync_ShouldUpdateHoliday()
    {
        // assign
        var holidayRequest = new HolidayRequest
        {
            Name = "Test holiday " + Guid.NewGuid(),
            DatePeriod = new DatePeriod
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            }
        };
        var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
        var updateRequest = new HolidayRequest
        {
            DatePeriod = createResult.Data.DatePeriod,
            Name = "New test holiday " + Guid.NewGuid(),
            OccursAnnually = createResult.Data.OccursAnnually
        };

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
        var holidayRequest = new HolidayRequest
        {
            Name = "Test holiday " + Guid.NewGuid(),
            DatePeriod = new DatePeriod
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            }
        };
        var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
        var updateRequest = new HolidayRequest
        {
            DatePeriod = null,
            Name = "New test holiday " + Guid.NewGuid(),
            OccursAnnually = createResult.Data.OccursAnnually
        };

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
        var holidayRequest = new HolidayRequest
        {
            Name = "Test holiday " + Guid.NewGuid(),
            DatePeriod = new DatePeriod
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            }
        };
        var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
        var updateRequest = new HolidayRequest
        {
            DatePeriod = createResult.Data.DatePeriod,
            Name = "New test holiday " + Guid.NewGuid(),
            OccursAnnually = createResult.Data.OccursAnnually
        };
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
        var holidayRequest = new HolidayRequest
        {
            Name = "Test holiday " + Guid.NewGuid(),
            DatePeriod = new DatePeriod
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            }
        };
        var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
        var updateRequest = new HolidayRequest
        {
            DatePeriod = createResult.Data.DatePeriod,
            Name = "New test holiday " + Guid.NewGuid(),
            OccursAnnually = createResult.Data.OccursAnnually
        };
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
        var holidayRequest = new HolidayRequest
        {
            Name = "Test holiday " + Guid.NewGuid(),
            DatePeriod = new DatePeriod
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            }
        };
        var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
        var updateRequest = new HolidayRequest
        {
            DatePeriod = createResult.Data.DatePeriod,
            Name = null,
            OccursAnnually = createResult.Data.OccursAnnually
        };
        
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
        var holidayRequest = new HolidayRequest
        {
            Name = "Test holiday " + Guid.NewGuid(),
            DatePeriod = new DatePeriod
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            }
        };
        var createResult = await _client.CreateHolidayAsync(_workspaceId, holidayRequest);
        var updateRequest = new HolidayRequest
        {
            DatePeriod = createResult.Data.DatePeriod,
            Name = "New test holiday " + Guid.NewGuid(),
            OccursAnnually = null
        };
        
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