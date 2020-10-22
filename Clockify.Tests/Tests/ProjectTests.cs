using System;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Estimates;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Workspaces;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests
{
    public class ProjectTests
    {
        private readonly ClockifyClient _client;
        private string _workspaceId;

        public ProjectTests()
        {
            _client = new ClockifyClient();
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
            _workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");
        }

        // TODO Uncomment when Clockify add deleting workspaces again

        // [OneTimeTearDown]
        // public async Task Cleanup()
        // {
        //  var currentUser = await _client.GetCurrentUserAsync();
        //  var changeResponse =
        //   await _client.SetActiveWorkspaceFor(currentUser.Data.Id, DefaultWorkspaceFixture.DefaultWorkspaceId);
        //  changeResponse.IsSuccessful.Should().BeTrue();
        //     var workspaceResponse = await _client.DeleteWorkspaceAsync(_workspaceId);
        //     workspaceResponse.IsSuccessful.Should().BeTrue();
        // }

        [Test]
        public async Task FindAllProjectsOnWorkspaceAsync_ShouldReturnProjectList()
        {
            var response = await _client.FindAllProjectsOnWorkspaceAsync(_workspaceId);
            response.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public async Task CreateProjectAsync_ShouldCreateProjectAndReturnProjectImplDto()
        {
            var projectRequest = new ProjectRequest
            {
                Name = "Test project " + Guid.NewGuid(),
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
        public async Task CreateProjectWithNoteAsync_ShouldCreteProjectAndReturnProjectImplDtoWithNote()
        {
            var projectRequest = new ProjectRequest
            {
                Name = "Note test project " + Guid.NewGuid(),
                Color = "#0000FF",
                Note = "Project Note Test"
            };
            var createResult = await _client.CreateProjectAsync(_workspaceId, projectRequest);
            createResult.IsSuccessful.Should().BeTrue();
            createResult.Data.Should().NotBeNull();
            createResult.Data.Note.Should().NotBeNull();

            var findResult = await _client.FindAllProjectsOnWorkspaceAsync(_workspaceId);
            findResult.IsSuccessful.Should().BeTrue();
            findResult.Data.Should().ContainEquivalentOf(createResult.Data);
        }

        [Test]
        public async Task CreateProjectWithEstimateAsync_ShouldCreteProjectAndReturnProjectImplDtoWithEstimateDto()
        {
            var projectRequest = new ProjectRequest
            {
                Name = "Estimate test project " + Guid.NewGuid(),
                Color = "#0000FF",
                Estimate = new EstimateRequest() { Estimate = 24, Type = EstimateType.Manual }
            };
            var createResult = await _client.CreateProjectAsync(_workspaceId, projectRequest);
            createResult.IsSuccessful.Should().BeTrue();
            createResult.Data.Should().NotBeNull();
            createResult.Data.Estimate.Should().NotBeNull();

            var findResult = await _client.FindAllProjectsOnWorkspaceAsync(_workspaceId);
            findResult.IsSuccessful.Should().BeTrue();
            findResult.Data.Should().ContainEquivalentOf(createResult.Data);
        }

        [Test]
        public async Task CreateProjectAsync_NullName_ShouldThrowArgumentException()
        {
            var projectRequest = new ProjectRequest
            {
                Name = null,
                Color = "#FF00FF"
            };
            Func<Task> create = async () => await _client.CreateProjectAsync(_workspaceId, projectRequest);

            await create.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"Value cannot be null. (Parameter '{nameof(ProjectRequest.Name)}')");
        }

        [Test]
        public async Task CreateProjectAsync_NullColor_ShouldThrowArgumentException()
        {
            var projectRequest = new ProjectRequest
            {
                Name = "Test project",
                Color = null
            };
            Func<Task> create = async () => await _client.CreateProjectAsync(_workspaceId, projectRequest);

            await create.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"Value cannot be null. (Parameter '{nameof(ProjectRequest.Color)}')");
        }

        [Test]
        public async Task DeleteProjectAsync_ShouldDeleteProject()
        {
            // Create project to delete
            var projectRequest = new ProjectRequest { Name = "DeleteProjectTest", Color = "#FFFFFF" };
            var response = await _client.CreateProjectAsync(_workspaceId, projectRequest);
            response.IsSuccessful.Should().BeTrue();
            var projectId = response.Data.Id;

            // Delete project
            var del = await _client.DeleteProjectAsync(_workspaceId, projectId);
            del.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public async Task FindProjectByIdAsync_ShouldReturnProjectImplDto()
        {
            // Create project to be found
            var projectRequest = new ProjectRequest { Name = "FindProjectByIdTest", Color = "#FFFFFF" };
            var response = await _client.CreateProjectAsync(_workspaceId, projectRequest);
            response.IsSuccessful.Should().BeTrue();
            var projectId = response.Data.Id;

            // Find project
            var find = await _client.FindProjectByIdAsync(_workspaceId, projectId);
            find.IsSuccessful.Should().BeTrue();

            // Delete project
            var del = await _client.DeleteProjectAsync(_workspaceId, projectId);
            del.IsSuccessful.Should().BeTrue();
        }
    }
}