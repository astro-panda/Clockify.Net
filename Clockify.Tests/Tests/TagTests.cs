﻿using System;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Tags;
using Clockify.Tests.Helpers;
using Clockify.Tests.Setup;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests
{
    public class TagTests
    {
        private readonly ClockifyClient _client;
        private string _workspaceId;

        public TagTests()
        {
            _client = new ClockifyClient(string.Empty);
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
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
        public async Task FindAllTagsOnWorkspaceAsync_ShouldReturnTagsList()
        {
            var response = await _client.FindAllTagsOnWorkspaceAsync(_workspaceId);
            response.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public async Task CreateTagAsync_ShouldCreateTagAndReturnTagDto()
        {
            var tagRequest = new TagRequest
            {
                Name = "Test tag " + Guid.NewGuid(),
            };
            var createResult = await _client.CreateTagAsync(_workspaceId, tagRequest);
            createResult.IsSuccessful.Should().BeTrue();
            createResult.Data.Should().NotBeNull();

            var findResult = await _client.FindAllTagsOnWorkspaceAsync(_workspaceId);
            findResult.IsSuccessful.Should().BeTrue();
            findResult.Data.Should().ContainEquivalentOf(createResult.Data);

            var deleteTag = await _client.ArchiveAndDeleteTagAsync(_workspaceId, createResult.Data.Id);
            deleteTag.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public async Task CreateTagAsync_NullName_ShouldThrowArgumentException()
        {
            var tagRequest = new TagRequest
            {
                Name = null,
            };
            Func<Task> create = () => _client.CreateTagAsync(_workspaceId, tagRequest);
            await create.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"Value cannot be null. (Parameter '{nameof(TagRequest.Name)}')");
        }
        
        [Test]
        public async Task DeleteTag_ShouldDeleteTag()
        {
            await using var tagSetup = new TagSetup(_client, _workspaceId);
            var tag = await tagSetup.SetupAsync();

            var tagUpdateRequest = new TagUpdateRequest() {
                Archived = true,
                Name = tag.Name
            };
            var archiveTag = await _client.UpdateTagAsync(_workspaceId, tag.Id, tagUpdateRequest);
            archiveTag.IsSuccessful.Should().BeTrue();

            var deleteTag = await _client.DeleteTagAsync(_workspaceId, tag.Id);
            deleteTag.IsSuccessful.Should().BeTrue();
            
            var findResult = await _client.FindAllTagsOnWorkspaceAsync(_workspaceId);
            findResult.IsSuccessful.Should().BeTrue();
            findResult.Data.Should().NotContain(x => x.Id == tag.Id);
        }
    }
}