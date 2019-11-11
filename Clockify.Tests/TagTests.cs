using System;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Tags;
using Clockify.Net.Models.Workspaces;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests {
	public class TagTests {
		private readonly ClockifyClient _client;
		private string _workspaceId;

		public TagTests() {
			_client = new ClockifyClient();
		}

		[SetUp]
		public async Task Setup() {
			var result = await _client.CreateWorkspaceAsync(new WorkspaceRequest { Name = "TagsWorkspace" });
			result.IsSuccessful.Should().BeTrue();
			_workspaceId = result.Data.Id;
		}

		[TearDown]
		public async Task Cleanup() {
			var result = await _client.DeleteWorkspaceAsync(_workspaceId);
			result.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task FindAllTagsOnWorkspaceAsync_ShouldReturnTagsList() {
			var response = await _client.FindAllTagsOnWorkspaceAsync(_workspaceId);
			response.IsSuccessful.Should().BeTrue();
		}

		[Test]
		public async Task CreateTagAsync_ShouldCreteTagAndReturnTagDto() {
			var tagRequest = new TagRequest {
				Name = "Test tag",
			};
			var createResult = await _client.CreateTagAsync(_workspaceId, tagRequest);
			createResult.IsSuccessful.Should().BeTrue();
			createResult.Data.Should().NotBeNull();

			var findResult = await _client.FindAllTagsOnWorkspaceAsync(_workspaceId);
			findResult.IsSuccessful.Should().BeTrue();
			findResult.Data.Should().ContainEquivalentOf(createResult.Data);
		}

		[Test]
		public async Task CreateProjectAsync_NullName_ShouldThrowArgumentException() {
			var tagRequest = new TagRequest {
				Name = null,
			};
			Func<Task> create = () => _client.CreateTagAsync(_workspaceId, tagRequest);
			await create.Should().ThrowAsync<ArgumentException>()
				.WithMessage($"Argument cannot be null. (Parameter '{nameof(TagRequest.Name)}')");
		}
	}
}