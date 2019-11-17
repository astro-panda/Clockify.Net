using System;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Tags;
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
			var result = await _client.CreateWorkspaceAsync(new WorkspaceRequest { Name = "TemplateWorkspace" });
			result.IsSuccessful.Should().BeTrue();
			_workspaceId = result.Data.Id;
		}

		[TearDown]
		public async Task Cleanup() {
			var result = await _client.DeleteWorkspaceAsync(_workspaceId);
			result.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task FindAllTemplatesOnWorkspaceAsync_ShouldReturnTagsList() {
			var response = await _client.FindAllTemplatesOnWorkspaceAsync(_workspaceId);
			response.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task CreateTemplatesAsync_ShouldCreteTemplateAndReturnTemplateDto() {
			var templatePatchRequest = new TemplateRequest() {
				Name = "Test template",
			};
			var createResult = await _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
			createResult.IsSuccessful.Should().BeTrue();
			createResult.Data.Should().NotBeNull();

			var findResult = await _client.FindAllTemplatesOnWorkspaceAsync(_workspaceId);
			findResult.IsSuccessful.Should().BeTrue();
			findResult.Data.Should().ContainEquivalentOf(createResult.Data);
		}

		[Test]
		public async Task CreateTemplatesAsync_NullName_ShouldThrowArgumentException() {
			var templatePatchRequest = new TemplateRequest() {
				Name = null,
			};
			Func<Task> create = () => _client.CreateTemplatesAsync(_workspaceId, templatePatchRequest);
			await create.Should().ThrowAsync<ArgumentException>()
				.WithMessage($"Argument cannot be null. (Parameter '{nameof(TagRequest.Name)}')");
		}
	}
}