using System;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Workspaces;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests {
	public class ProjectTests {
		private readonly ClockifyClient _client;
		private string _workspaceId;

		public ProjectTests() {
			_client = new ClockifyClient();
		}

		[SetUp]
		public async Task Setup() {
			var workspaceResponse = await _client.CreateWorkspaceAsync(new WorkspaceRequest { Name = "ProjectsWorkspace" });
			workspaceResponse.IsSuccessful.Should().BeTrue();
			_workspaceId = workspaceResponse.Data.Id;
		}

		[TearDown]
		public async Task Cleanup() {
			var workspaceResponse = await _client.DeleteWorkspaceAsync(_workspaceId);
			workspaceResponse.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task FindAllProjectsOnWorkspaceAsync_ShouldReturnProjectList() {
			var response = await _client.FindAllProjectsOnWorkspaceAsync(_workspaceId);
			response.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task CreateProjectAsync_ShouldCreteProjectAndReturnProjectImplDto() {
			var projectRequest = new ProjectRequest {
				Name = "Test project",
				Color = "#FF00FF"
			};
			var createResult = await _client.CreateProjectAsync(_workspaceId, projectRequest);
			createResult.IsSuccessful.Should().BeTrue();
			createResult.Data.Should().NotBeNull();

			var findResult = await _client.FindAllProjectsOnWorkspaceAsync(_workspaceId);
			findResult.IsSuccessful.Should().BeTrue();
			findResult.Data.Should().ContainEquivalentOf(createResult.Data);
		}

		[Test]
		public async Task CreateProjectAsync_NullName_ShouldThrowArgumentException() {
			var projectRequest = new ProjectRequest {
				Name = null,
				Color = "#FF00FF"
			};
			Func<Task> create = async () => await _client.CreateProjectAsync(_workspaceId, projectRequest);

			await create.Should().ThrowAsync<ArgumentException>()
				.WithMessage($"Argument cannot be null. (Parameter '{nameof(ProjectRequest.Name)}')");
		}

		[Test]
		public async Task CreateProjectAsync_NullColor_ShouldThrowArgumentException() {
			var projectRequest = new ProjectRequest {
				Name = "Test project",
				Color = null
			};
			Func<Task> create = async () => await _client.CreateProjectAsync(_workspaceId, projectRequest);

			await create.Should().ThrowAsync<ArgumentException>()
				.WithMessage($"Argument cannot be null. (Parameter '{nameof(ProjectRequest.Color)}')");
		}

		[Test]
		public async Task CreateWorkspace_ShouldCreateWorkspace() {
			// Create project to delete
			var projectRequest = new ProjectRequest { Name = "DeleteProjectTest" , Color = "#FFFFFF"};
			var response = await _client.CreateProjectAsync(_workspaceId, projectRequest);
			response.IsSuccessful.Should().BeTrue();
			var projectId = response.Data.Id;

			// Delete project
			var del = await _client.DeleteProjectAsync(_workspaceId, projectId);
			del.IsSuccessful.Should().BeTrue();
		}

	}
}