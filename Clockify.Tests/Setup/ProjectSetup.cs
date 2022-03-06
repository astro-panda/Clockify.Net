using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.HourlyRates;
using Clockify.Net.Models.Projects;
using Clockify.Tests.Helpers;
using FluentAssertions;

namespace Clockify.Tests.Setup {
	public class ProjectSetup : IAsyncDisposable {
		private readonly ClockifyClient _client;
		private readonly string _workspaceName;
		private string _projectId = string.Empty;

		public ProjectSetup(ClockifyClient _client, string workspaceName) {
			this._client = _client;
			_workspaceName = workspaceName;
		}

		public async Task<ProjectDtoImpl> SetupAsync(string clientId = "", [CallerMemberName] string callerName = "") {
			var projectRequest = new ProjectRequest {
				Name = $"Test project {Guid.NewGuid()}: {callerName}",
				Color = "#FF00FF",
				HourlyRate = new HourlyRateRequest { Amount = 1234 },
				ClientId = clientId
			};

			var createProject = await _client.CreateProjectAsync(_workspaceName, projectRequest);
			createProject.IsSuccessful.Should().BeTrue();
			createProject.Data.Should().NotBeNull();

			_projectId = createProject.Data.Id;
			return createProject.Data;
		}


		public async ValueTask DisposeAsync() {
			await _client.ArchiveAndDeleteProject(_workspaceName, _projectId);
		}
	}
}