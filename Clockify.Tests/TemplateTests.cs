using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Tags;
using Clockify.Net.Models.Tasks;
using Clockify.Net.Models.Templates;
using Clockify.Net.Models.Workspaces;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests {
	public class TemplateTests {
		private readonly ClockifyClient _client;
		private string _workspaceId;

		public TemplateTests() {
			_client = new ClockifyClient();
		}

		[SetUp]
		public async Task Setup() {
			var workspaceResponse = await _client.CreateWorkspaceAsync(new WorkspaceRequest { Name = "TemplateWorkspace" });
			workspaceResponse.IsSuccessful.Should().BeTrue();
			_workspaceId = workspaceResponse.Data.Id;
		}

		[TearDown]
		public async Task Cleanup() {
			var workspaceResponse = await _client.DeleteWorkspaceAsync(_workspaceId);
			workspaceResponse.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task FindAllTemplatesOnWorkspaceAsync_ShouldReturnTagsList() {
			var response = await _client.FindAllTemplatesOnWorkspaceAsync(_workspaceId);
			response.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task CreateTemplatesAsync_ShouldCreteTemplateAndReturnTemplateDto() {
			// Create project for test
			var projectRequest = new ProjectRequest { Name = "Template tet project", Color = "#FFFFFF"};
			var projectResponse = await _client.CreateProjectAsync(_workspaceId, projectRequest);
			projectResponse.IsSuccessful.Should().BeTrue();
			var projectId = projectResponse.Data.Id;
			// Create task
			var taskRequest = new TaskRequest { Name = "Template create task" };
			var taskResponse = await _client.CreateTaskAsync(_workspaceId, projectId, taskRequest);
			taskResponse.IsSuccessful.Should().BeTrue();
			var taskId = taskResponse.Data.Id;

			var templatePatchRequest = new TemplateRequest() {
				Name = "Test template",
				ProjectsAndTasks = new List<ProjectsTaskTupleRequest>() {
					new ProjectsTaskTupleRequest {
						ProjectId = projectId,
						TaskId = taskId
					}
				}
			};

			var createResult = await _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
			createResult.IsSuccessful.Should().BeTrue();
			createResult.Data.Should().NotBeNull();

			var findResult = await _client.FindAllTemplatesOnWorkspaceAsync(_workspaceId);
			findResult.IsSuccessful.Should().BeTrue();
			findResult.Data.Should().BeEquivalentTo(createResult.Data);
		}

		[Test]
		public async Task CreateTemplatesAsync_NullName_ShouldThrowArgumentException() {
			var templatePatchRequest = new TemplateRequest() {
				Name = null,
			};
			Func<Task> create = () => _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
			await create.Should().ThrowAsync<ArgumentException>()
				.WithMessage($"Argument cannot be null. (Parameter '{nameof(TemplateRequest.Name)}')");
		}

		[Test]
		public async Task CreateTemplatesAsync_NullProjectsAndTasks_ShouldThrowArgumentException() {
			var templatePatchRequest = new TemplateRequest() {
				Name = "Test name",
				ProjectsAndTasks = null
			};
			Func<Task> create = () => _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
			await create.Should().ThrowAsync<ArgumentException>()
				.WithMessage($"Argument cannot be null. (Parameter '{nameof(TemplateRequest.ProjectsAndTasks)}')");
		}
	}
}