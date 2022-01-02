using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Clients;
using Clockify.Net.Models.HourlyRates;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Reports;
using Clockify.Net.Models.TimeEntries;
using Clockify.Net.Models.Users;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using TimeZoneConverter;

namespace Clockify.Tests.Tests {
	public class ReportTests {
		private readonly ClockifyClient _client;
		private string _workspaceId;

		public ReportTests() {
			_client = new ClockifyClient();
		}

		[OneTimeSetUp]
		public async Task Setup() {
			_workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");
		}

		[Test]
		public async Task GetDetailedReportAsync_ShouldReturnDetailedReportDto() {
			var now = DateTimeOffset.UtcNow;
			var client = await SetupHelper.CreateTestClientAsync(_client, _workspaceId);
			var project = await SetupHelper.CreateTestProjectAsync(_client, _workspaceId, client.Id);
			await SetupHelper.CreateTestTimeEntryAsync(_client, _workspaceId, now, project.Id);
			var userResponse = await _client.GetCurrentUserAsync();
			userResponse.IsSuccessful.Should().BeTrue();

			var nowWithTimeZone = DateTimeHelper.ConvertToTimeZone(userResponse.Data.Settings.TimeZone, now);

			var detailedReportRequest = new DetailedReportRequest {
				ExportType = ExportType.JSON,
				DateRangeStart = nowWithTimeZone.AddMinutes(-2),
				DateRangeEnd = nowWithTimeZone.AddMinutes(2),
				SortOrder = SortOrderType.DESCENDING,
				Description = String.Empty,
				Rounding = false,
				WithoutDescription = false,
				AmountShown = AmountShownType.EARNED,
				Clients = new ClientsFilterDto {
					Contains = ContainsType.CONTAINS,
					Ids = new List<string> { client.Id },
					Status = StatusType.ACTIVE
				},
				DetailedFilter = new DetailedFilterDto {
					SortColumn = SortColumnType.DATE,
					Page = 1,
					PageSize = 50
				},
				TimeZone = userResponse.Data.Settings.TimeZone
			};

			var getDetailedReportResult = await _client.GetDetailedReportAsync(_workspaceId, detailedReportRequest);
			getDetailedReportResult.IsSuccessful.Should().BeTrue();
			getDetailedReportResult.Data.Should().NotBeNull();
			getDetailedReportResult.Data.TimeEntries.Should().HaveCountGreaterOrEqualTo(1);
			
			// Cleanup
			var deleteProject = await _client.ArchiveAndDeleteProject(_workspaceId, project.Id);
			deleteProject.IsSuccessful.Should().BeTrue();
		}



		[Test]
		public async Task GetSummaryReportAsync_ShouldReturnSummaryReportDto() {
			var now = DateTimeOffset.UtcNow;
			var client = await SetupHelper.CreateTestClientAsync(_client, _workspaceId);
			var project = await SetupHelper.CreateTestProjectAsync(_client, _workspaceId, client.Id);
			await SetupHelper.CreateTestTimeEntryAsync(_client, _workspaceId, now, project.Id);
			var userResponse = await _client.GetCurrentUserAsync();
			userResponse.IsSuccessful.Should().BeTrue();

			var nowWithTimeZone = DateTimeHelper.ConvertToTimeZone(userResponse.Data.Settings.TimeZone, now);

			var summaryReportRequest = new SummaryReportRequest() {
				ExportType = ExportType.JSON,
				DateRangeStart = nowWithTimeZone.AddMinutes(-2),
				DateRangeEnd = nowWithTimeZone.AddMinutes(2),
				SortOrder = SortOrderType.DESCENDING,
				Description = String.Empty,
				Rounding = false,
				WithoutDescription = false,
				AmountShown = AmountShownType.EARNED,
				Clients = new ClientsFilterDto {
					Contains = ContainsType.CONTAINS,
					Ids = new List<string> { client.Id },
					Status = StatusType.ACTIVE
				},
				SummaryFilter = new SummaryFilterDto() {
					Groups = new List<GroupType>() {
						GroupType.PROJECT
					}
				},
				TimeZone = userResponse.Data.Settings.TimeZone
			};

			var getSummaryReportResult = await _client.GetSummaryReportAsync(_workspaceId, summaryReportRequest);
			
			getSummaryReportResult.IsSuccessful.Should().BeTrue();
			getSummaryReportResult.Data.Should().NotBeNull();
			
			// Cleanup
			var deleteProject = await _client.ArchiveAndDeleteProject(_workspaceId, project.Id);
			deleteProject.IsSuccessful.Should().BeTrue();
		}
	}
}