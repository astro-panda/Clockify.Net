using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Tasks;
using Clockify.Net.Models.Templates;
using Clockify.Net.Models.Workspaces;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests
{
    public class TemplateTests
    {
        private readonly ClockifyClient _client;
        private string _workspaceId;

        public TemplateTests()
        {
            _client = new ClockifyClient();
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
            _workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "TemplateWorkspace");
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
        public async Task FindAllTemplatesOnWorkspaceAsync_ShouldReturnTagsList()
        {
            var response = await _client.FindAllTemplatesOnWorkspaceAsync(_workspaceId);
            response.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public async Task CreateTemplatesAsync_ShouldCreteTemplateAndReturnTemplateDto()
        {
            // Create project for test
            var projectRequest = new ProjectRequest {Name = "Create Template test project " + Guid.NewGuid(), Color = "#FFFFFF"};
            var projectResponse = await _client.CreateProjectAsync(_workspaceId, projectRequest);
            projectResponse.IsSuccessful.Should().BeTrue();
            var projectId = projectResponse.Data.Id;
            // Create task
            var taskRequest = new TaskRequest {Name = "Template create task " + Guid.NewGuid()};
            var taskResponse = await _client.CreateTaskAsync(_workspaceId, projectId, taskRequest);
            taskResponse.IsSuccessful.Should().BeTrue();
            var taskId = taskResponse.Data.Id;

            var templatePatchRequest = new TemplateRequest()
            { 
                Name = "Create Test template " + Guid.NewGuid(),
                ProjectsAndTasks = new List<ProjectsTaskTupleRequest>()
                {
                    new ProjectsTaskTupleRequest
                    {
                        ProjectId = projectId,
                        TaskId = taskId
                    }
                }
            };

            var createResult = await _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
            createResult.IsSuccessful.Should().BeTrue();
            createResult.Data.Should().NotBeNull();
        }

        [Test]
        public async Task GetTemplateAsync_ShouldReturnTemplateDto()
        {
            // Create project for test
            var projectRequest = new ProjectRequest {Name = "Get Template test project " + Guid.NewGuid(), Color = "#FFFFFF"};
            var projectResponse = await _client.CreateProjectAsync(_workspaceId, projectRequest);
            projectResponse.IsSuccessful.Should().BeTrue();
            var projectId = projectResponse.Data.Id;
            // Create task
            var taskRequest = new TaskRequest {Name = "Template create task " + Guid.NewGuid()};
            var taskResponse = await _client.CreateTaskAsync(_workspaceId, projectId, taskRequest);
            taskResponse.IsSuccessful.Should().BeTrue();
            var taskId = taskResponse.Data.Id;

            var templatePatchRequest = new TemplateRequest()
            {
                Name = "Get Test template " + Guid.NewGuid(),
                ProjectsAndTasks = new List<ProjectsTaskTupleRequest>()
                {
                    new ProjectsTaskTupleRequest
                    {
                        ProjectId = projectId,
                        TaskId = taskId
                    }
                }
            };

            var createResult = await _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
            createResult.IsSuccessful.Should().BeTrue();
            createResult.Data.Should().NotBeNull();

            var getResponse = await _client.GetTemplateAsync(_workspaceId, createResult.Data.First().Id);
            getResponse.IsSuccessful.Should().BeTrue();
            getResponse.Data.Should().BeEquivalentTo(createResult.Data.First());
        }

        [Test]
        public async Task UpdateTemplateAsync_ShouldReturnTemplateDto()
        {
            // Create project for test
            var projectRequest = new ProjectRequest {Name = "Update Template test project " + Guid.NewGuid(), Color = "#FFFFFF"};
            var projectResponse = await _client.CreateProjectAsync(_workspaceId, projectRequest);
            projectResponse.IsSuccessful.Should().BeTrue();
            var projectId = projectResponse.Data.Id;
            // Create task
            var taskRequest = new TaskRequest {Name = "Template create task " + Guid.NewGuid()};
            var taskResponse = await _client.CreateTaskAsync(_workspaceId, projectId, taskRequest);
            taskResponse.IsSuccessful.Should().BeTrue();
            var taskId = taskResponse.Data.Id;

            var templatePatchRequest = new TemplateRequest()
            {
                Name = "Update Test template " + Guid.NewGuid(),
                ProjectsAndTasks = new List<ProjectsTaskTupleRequest>()
                {
                    new ProjectsTaskTupleRequest
                    {
                        ProjectId = projectId,
                        TaskId = taskId
                    }
                }
            };

            var createResult = await _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
            createResult.IsSuccessful.Should().BeTrue();
            createResult.Data.Should().NotBeNull();

            var patchRequest = new TemplatePatchRequest {Name = "Updated " + Guid.NewGuid()};
            var templateDto = createResult.Data.First();
            templateDto.Name = patchRequest.Name;
            var getResponse = await _client.UpdateTemplateAsync(_workspaceId, templateDto.Id, patchRequest);

            getResponse.IsSuccessful.Should().BeTrue();
            getResponse.Data.Should().BeEquivalentTo(templateDto);
        }

        [Test]
        public async Task DeleteTemplateAsync_ShouldReturnTemplateDto()
        {
            // Create project for test
            var projectRequest = new ProjectRequest {Name = "Delete Template test project " + Guid.NewGuid(), Color = "#FFFFFF"};
            var projectResponse = await _client.CreateProjectAsync(_workspaceId, projectRequest);
            projectResponse.IsSuccessful.Should().BeTrue();
            var projectId = projectResponse.Data.Id;
            // Create task
            var taskRequest = new TaskRequest {Name = "Template create task " + Guid.NewGuid()};
            var taskResponse = await _client.CreateTaskAsync(_workspaceId, projectId, taskRequest);
            taskResponse.IsSuccessful.Should().BeTrue();
            var taskId = taskResponse.Data.Id;

            var templatePatchRequest = new TemplateRequest()
            {
                Name = "Delete Test template " + Guid.NewGuid(),
                ProjectsAndTasks = new List<ProjectsTaskTupleRequest>()
                {
                    new ProjectsTaskTupleRequest
                    {
                        ProjectId = projectId,
                        TaskId = taskId
                    }
                }
            };

            var createResult = await _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
            createResult.IsSuccessful.Should().BeTrue();
            createResult.Data.Should().NotBeNull();

            var deleteResponse = await _client.DeleteTemplateAsync(_workspaceId, createResult.Data.First().Id);
            deleteResponse.IsSuccessful.Should().BeTrue();
            deleteResponse.Data.Should().BeEquivalentTo(createResult.Data.First());
        }

        [Test]
        public async Task UpdateTemplateAsync_NullTemplatePatchRequest_ShouldThrowArgumentException()
        {
            Func<Task> create = () => _client.UpdateTemplateAsync(_workspaceId, "", null);
            await create.Should().ThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task UpdateTemplateAsync_NullName_ShouldThrowArgumentException()
        {
            var templatePatchRequest = new TemplatePatchRequest()
            {
                Name = null,
            };
            Func<Task> create = () => _client.UpdateTemplateAsync(_workspaceId, "", templatePatchRequest);
            await create.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"Value cannot be null. (Parameter '{nameof(TemplatePatchRequest.Name)}')");
        }

        [Test]
        public async Task CreateTemplatesAsync_NullTemplateRequest_ShouldThrowArgumentException()
        {
            Func<Task> create = () => _client.CreateTemplatesAsync(_workspaceId, null);
            await create.Should().ThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task CreateTemplatesAsync_NullName_ShouldThrowArgumentException()
        {
            var templatePatchRequest = new TemplateRequest()
            {
                Name = null,
            };
            Func<Task> create = () => _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
            await create.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"Value cannot be null. (Parameter '{nameof(TemplateRequest.Name)}')");
        }

        [Test]
        public async Task CreateTemplatesAsync_NullProjectsAndTasks_ShouldThrowArgumentException()
        {
            var templatePatchRequest = new TemplateRequest()
            {
                Name = "Test name " + Guid.NewGuid(),
                ProjectsAndTasks = null
            };
            Func<Task> create = () => _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
            await create.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"Value cannot be null. (Parameter '{nameof(TemplateRequest.ProjectsAndTasks)}')");
        }

        [Test]
        public async Task CreateTemplatesAsync_NullProjectId_ShouldThrowArgumentException()
        {
            var templatePatchRequest = new TemplateRequest()
            {
                Name = "Test name " + Guid.NewGuid(),
                ProjectsAndTasks = new List<ProjectsTaskTupleRequest>
                {
                    new ProjectsTaskTupleRequest
                    {
                        ProjectId = null,
                        TaskId = "Test"
                    }
                }
            };
            Func<Task> create = () => _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
            await create.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"Value cannot be null. (Parameter '{nameof(ProjectsTaskTupleRequest.ProjectId)}')");
        }

        [Test]
        public async Task CreateTemplatesAsync_NullTaskId_ShouldThrowArgumentException()
        {
            var templatePatchRequest = new TemplateRequest()
            {
                Name = "Test name " + Guid.NewGuid(),
                ProjectsAndTasks = new List<ProjectsTaskTupleRequest>
                {
                    new ProjectsTaskTupleRequest
                    {
                        ProjectId = "Test",
                        TaskId = null
                    }
                }
            };
            Func<Task> create = () => _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
            await create.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"Value cannot be null. (Parameter '{nameof(ProjectsTaskTupleRequest.TaskId)}')");
        }
    }
}