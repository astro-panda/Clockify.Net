using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Clients;
using Clockify.Net.Models.HourlyRates;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.TimeEntries;
using Clockify.Net.Models.Workspaces;
using FluentAssertions;
using RestSharp;

namespace Clockify.Tests.Helpers {
	public class SetupHelper {
		/// <summary>
		/// Creates or finds workspace and return workspace id
		/// </summary>
		public static async Task<string> CreateOrFindWorkspaceAsync(ClockifyClient client, string workspaceName) {
			var workspaceResponse = await client.CreateWorkspaceAsync(new WorkspaceRequest { Name = workspaceName });
			string workspaceId;
			// workspaceResponse.IsSuccessful.Should().BeTrue();

			if (workspaceResponse.IsSuccessful) {
				workspaceId = workspaceResponse.Data.Id;
			}
			else if (WorkspaceAlreadyExist(workspaceResponse)) {
				var workspacesResponse = await client.GetWorkspacesAsync();
				var workspace = workspacesResponse.Data.SingleOrDefault(dto => dto.Name == workspaceName);
				if (workspace == null)
					throw new NullReferenceException($"Workspace {workspaceName} do not exist.");
				return workspace.Id;
			}
			else {
				throw new InvalidOperationException($"Cannot create or find workspace: {workspaceResponse.Content}");
			}


			return workspaceId;
		}

		/// <summary>
		/// Creates client
		/// </summary>
		public static async Task<ClientDto> CreateTestClientAsync(ClockifyClient client, string workspaceName) {
			var clientRequest = new ClientRequest {
				Name = "GetDetailedReportAsync " + Guid.NewGuid()
			};

			var createClientResponse = await client.CreateClientAsync(workspaceName, clientRequest);
			createClientResponse.IsSuccessful.Should().BeTrue();
			return createClientResponse.Data;
		}
	
		public static async Task<ProjectDtoImpl> CreateTestProjectAsync(ClockifyClient client, string workspaceName, string clientId) {
			var projectRequest = new ProjectRequest {
				Name = "GetDetailedReportAsync " + Guid.NewGuid(),
				Color = "#FF00FF",
				HourlyRate = new HourlyRateRequest { Amount = 1234 },
				ClientId = clientId
			};

			var createProject = await client.CreateProjectAsync(workspaceName, projectRequest);
			createProject.IsSuccessful.Should().BeTrue();
			createProject.Data.Should().NotBeNull();

			ProjectDtoImpl project = createProject.Data;
			return project;
		}
		
		public static async Task<TimeEntryDtoImpl> CreateTestTimeEntryAsync(ClockifyClient client, string workspaceId, DateTimeOffset start, string projectId) {
			var timeEntryRequest = new TimeEntryRequest {
				Start = start,
				End = start.AddSeconds(30),
				ProjectId = projectId
			};

			var createResult = await client.CreateTimeEntryAsync(workspaceId, timeEntryRequest);
			createResult.IsSuccessful.Should().BeTrue();
			return createResult.Data;
		}
		
		public async Task<string> CreateOrFindWorkspaceAsync(string workspaceName) {
			return await CreateOrFindWorkspaceAsync(new ClockifyClient(), workspaceName);
		}


		private static bool WorkspaceAlreadyExist(IRestResponse<WorkspaceDto> workspaceResponse) {
			return workspaceResponse.StatusCode == HttpStatusCode.BadRequest &&
			       workspaceResponse.Content.Contains("already exist");
		}
	}
}