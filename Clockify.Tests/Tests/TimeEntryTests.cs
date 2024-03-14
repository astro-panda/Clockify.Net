using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Tags;
using Clockify.Net.Models.TimeEntries;
using Clockify.Tests.Helpers;
using Clockify.Tests.Setup;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

namespace Clockify.Tests.Tests {
	public class TimeEntryTests {
		private readonly ClockifyClient _client;
		private string _workspaceId;

		public TimeEntryTests() {
			_client = new ClockifyClient(string.Empty);
		}

		[OneTimeSetUp]
		public async Task Setup() {
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
		public async Task FindAllTagsOnWorkspaceAsync_ShouldReturnTagsList() {
			var response = await _client.FindAllTagsOnWorkspaceAsync(_workspaceId);
			response.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task CreateTimeEntryAsync_ShouldCreteTimeEntryAndReturnTimeEntryDtoImpl() {
			var now = DateTimeOffset.UtcNow;
			var timeEntryRequest = new TimeEntryRequest {
				Start = now,
				End = now.AddSeconds(1),
			};
			var createResult = await _client.CreateTimeEntryAsync(_workspaceId, timeEntryRequest);
			createResult.IsSuccessful.Should().BeTrue();
			createResult.Data.Should().NotBeNull();
			createResult.Data.TimeInterval.Start.Should().BeCloseTo(now, 1.Seconds());
		}

		[Test]
		public async Task CreateTimeEntryAsyncForAnotherUser_ShouldCreteTimeEntryAndReturnTimeEntryDtoImpl() {
			var response = await _client.GetCurrentUserAsync();
			response.IsSuccessful.Should().BeTrue();
			response.Data.Should().NotBeNull();

			var now = DateTimeOffset.UtcNow;
			var timeEntryRequest = new TimeEntryRequest {
				Start = now,
				End = now.AddHours(1)
			};
			var userId = response.Data.Id; // Using my own user for testing
			var createResult = await _client.CreateTimeEntryForAnotherUserAsync(_workspaceId, userId, timeEntryRequest);
			createResult.IsSuccessful.Should().BeTrue();
			createResult.Data.Should().NotBeNull();
			createResult.Data.TimeInterval.Start.Should().BeCloseTo(now, 1.Seconds());
		}

		[Test]
		public async Task CreateTimeEntryAsync_NullStart_ShouldThrowArgumentException() {
			var timeEntryRequest = new TimeEntryRequest {
				Start = null,
			};
			Func<Task> create = () => _client.CreateTimeEntryAsync(_workspaceId, timeEntryRequest);
			await create.Should().ThrowAsync<ArgumentException>()
			            .WithMessage($"Value cannot be null. (Parameter '{nameof(TimeEntryRequest.Start)}')");
		}

		[Test]
		public async Task GetTimeEntryFromWorkspaceAsync_ShouldReturnTimeEntryDtoImpl() {
			var now = DateTimeOffset.UtcNow;
			var timeEntryRequest = new TimeEntryRequest {
				Start = now,
				End = now.AddSeconds(1),
				Description = Guid.NewGuid().ToString()
			};
			var createResult = await _client.CreateTimeEntryAsync(_workspaceId, timeEntryRequest);
			createResult.IsSuccessful.Should().BeTrue();
			createResult.Data.Should().NotBeNull();
			var timeEntryId = createResult.Data.Id;

			var getResult = await _client.GetTimeEntryAsync(_workspaceId, timeEntryId);
			getResult.IsSuccessful.Should().BeTrue();
			getResult.Data.Should().NotBeNull();
			getResult.Data.Should().BeEquivalentTo(createResult.Data);
		}

		[Test]
		[Ignore("Clockify bug - Duplicate unique key error, HTTP 501 error")]
		public async Task UpdateTimeEntryAsync_ShouldUpdateTimeEntryDtoImpl() {
			var now = DateTimeOffset.UtcNow;
			var timeEntryRequest = new TimeEntryRequest {
				Start = now,
				End = now.AddSeconds(1),
			};
			var createResult = await _client.CreateTimeEntryAsync(_workspaceId, timeEntryRequest);
			createResult.IsSuccessful.Should().BeTrue();
			createResult.Data.Should().NotBeNull();
			var timeEntryId = createResult.Data.Id;

			var updateTimeEntryRequest = new UpdateTimeEntryRequest {
				Start = now.AddSeconds(-1),
				Billable = true,
			};
			var updateResult = await _client.UpdateTimeEntryAsync(_workspaceId, timeEntryId, updateTimeEntryRequest);
			updateResult.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task UpdateTimeEntryAsync_NullStart_ShouldThrowArgumentException() {
			var updateTimeEntryRequest = new UpdateTimeEntryRequest {
				Start = null,
			};
			Func<Task> create = () => _client.UpdateTimeEntryAsync(_workspaceId, "", updateTimeEntryRequest);
			await create.Should().ThrowAsync<ArgumentException>()
			            .WithMessage($"Value cannot be null. (Parameter '{nameof(TimeEntryRequest.Start)}')");
		}

		[Test]
		public async Task UpdateTimeEntryAsync_NullBillable_ShouldThrowArgumentException() {
			var updateTimeEntryRequest = new UpdateTimeEntryRequest {
				Start = DateTimeOffset.UtcNow,
				Billable = null
			};
			Func<Task> create = () => _client.UpdateTimeEntryAsync(_workspaceId, "", updateTimeEntryRequest);
			await create.Should().ThrowAsync<ArgumentException>()
			            .WithMessage($"Value cannot be null. (Parameter '{nameof(TimeEntryRequest.Billable)}')");
		}

		[Test]
		public async Task DeleteTimeEntryAsync_ShouldDeleteTimeEntry() {
			var now = DateTimeOffset.UtcNow;
			var timeEntryRequest = new TimeEntryRequest {
				Start = now,
				End = now.AddSeconds(1),
				Description = Guid.NewGuid().ToString(),
			};
			var createResult = await _client.CreateTimeEntryAsync(_workspaceId, timeEntryRequest);
			createResult.IsSuccessful.Should().BeTrue();
			var timeEntryId = createResult.Data.Id;

			var deleteResult = await _client.DeleteTimeEntryAsync(_workspaceId, timeEntryId);
			deleteResult.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task FindAllTimeEntriesForUserAsync_ShouldReturnTimeEntryDtoImplList() {
			await using var tagSetup = new TagSetup(_client, _workspaceId);
			var tag = await tagSetup.SetupAsync();

			var now = DateTimeOffset.UtcNow;
			var timeEntryRequest = new TimeEntryRequest {
				Start = now,
				End = now.AddSeconds(1),
				Description = "",
				TagIds = new List<string>() { tag.Id }
			};

			var createTimEntryResult = await _client.CreateTimeEntryAsync(_workspaceId, timeEntryRequest);
			createTimEntryResult.IsSuccessful.Should().BeTrue();

			var userResponse = await _client.GetCurrentUserAsync();
			userResponse.IsSuccessful.Should().BeTrue();


			var response = await _client.FindAllTimeEntriesForUserAsync(_workspaceId, userResponse.Data.Id,
				start: DateTimeOffset.Now.AddDays(-1),
				end: DateTimeOffset.Now.AddDays(1));

			response.IsSuccessful.Should().BeTrue();
			response.Data.Should().ContainEquivalentOf(createTimEntryResult.Data);

			// Clean up
			await _client.DeleteTimeEntryAsync(_workspaceId, createTimEntryResult.Data.Id);
		}

		[Test]
		public async Task FindAllHydratedTimeEntriesForUserAsync_ShouldReturnHydratedTimeEntryDtoImplList() {
			const int hourlyRateAmount = 1234;

			// Create project
			await using var projectSetup = new ProjectSetup(_client, _workspaceId);
			var project = await projectSetup.SetupAsync();

			var now = DateTimeOffset.UtcNow;
			var timeEntryRequest = new TimeEntryRequest {
				Start = now,
				End = now.AddSeconds(1),
				ProjectId = project.Id
			};

			var createResult = await _client.CreateTimeEntryAsync(_workspaceId, timeEntryRequest);
			createResult.IsSuccessful.Should().BeTrue();

			var userResponse = await _client.GetCurrentUserAsync();
			userResponse.IsSuccessful.Should().BeTrue();

			var response = await _client.FindAllHydratedTimeEntriesForUserAsync(_workspaceId, userResponse.Data.Id,
				start: now.AddDays(-1),
				end: now.AddDays(1));

			response.IsSuccessful.Should().BeTrue();
			response.Data.Should().Contain(timeEntry => timeEntry.Id.Equals(createResult.Data.Id));
			response.Data.Should().Contain(timeEntry =>
				timeEntry.HourlyRate != null && timeEntry.HourlyRate.Amount.Equals(hourlyRateAmount));
		}

		[Test]
		public async Task FindAllTimeEntriesForProjectAsync_ShouldReturnTimeEntryDtoImplList() {
			// Create project
			await using var projectSetup = new ProjectSetup(_client, _workspaceId);
			var project = await projectSetup.SetupAsync();
			// Create TimeEntries
			var now = DateTimeOffset.UtcNow;
			var timeEntry1Request = new TimeEntryRequest {
				ProjectId = project.Id,
				Start = now,
				End = now.AddMinutes(2),
				Description = "TimeEntry1"
			};

			var addTimeEntry1 = await _client.CreateTimeEntryAsync(_workspaceId, timeEntry1Request);
			addTimeEntry1.IsSuccessful.Should().BeTrue();
			addTimeEntry1.Data.Should().NotBeNull();

			TimeEntryDtoImpl timeEntry1 = addTimeEntry1.Data;

			var timeEntry2Request = new TimeEntryRequest {
				ProjectId = project.Id,
				Start = now.AddDays(-1),
				End = now.AddMinutes(3),
				Description = "TimeEntry2"
			};


			var addTimeEntry2 = await _client.CreateTimeEntryAsync(_workspaceId, timeEntry2Request);
			addTimeEntry2.IsSuccessful.Should().BeTrue();
			addTimeEntry2.Data.Should().NotBeNull();

			TimeEntryDtoImpl timeEntry2 = addTimeEntry2.Data;


			// Send request

			var response = await _client.FindAllTimeEntriesForProjectAsync(_workspaceId, projectId: project.Id,
				start: DateTimeOffset.Now.AddDays(-2),
				end: DateTimeOffset.Now.AddDays(1));
			//response.IsSuccessful.Should().BeTrue();
			response.Data.Should().NotBeNull();

			List<TimeEntryDtoImpl> responseContent = response.Data as List<TimeEntryDtoImpl>;

			responseContent.Should().Contain(timeEntry => timeEntry.Id.Equals(timeEntry1.Id));
			responseContent.Should().Contain(timeEntry => timeEntry.Id.Equals(timeEntry2.Id));


			// Clean up
			await _client.DeleteTimeEntryAsync(_workspaceId, addTimeEntry1.Data.Id);
			await _client.DeleteTimeEntryAsync(_workspaceId, addTimeEntry2.Data.Id);
		}
	}
}