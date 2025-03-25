using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Clockify.Net;
using Clockify.Net.Models.Users;
using Clockify.Tests.Helpers;
using Clockify.Tests.Setup;

using FluentAssertions;

using NUnit.Framework;

namespace Clockify.Tests.Tests
{
    public class UserGroupTests
    {
        private readonly ClockifyClient _client;
        private string _workspaceId;

        public UserGroupTests()
        {
            string legacyApiKeyVariable = Environment.GetEnvironmentVariable(Constants.ApiKeyVariableName);
            _client = new ClockifyClient(legacyApiKeyVariable);
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
            string workspaceName = "Clockify.NetTestWorkspace";
            //string workspaceName = "gemelo gmbh";
            var workspacesResponse = await _client.GetWorkspacesAsync();
            var workspace = workspacesResponse.Data.SingleOrDefault(dto => dto.Name.Contains(workspaceName));
            if (workspace == null)
                throw new NullReferenceException($"Workspace {workspaceName} do not exist.");
            _workspaceId = workspace.Id;
        }

        [Test]
        public async Task FindAllGroupsOnWorkspaceAsync_ShouldReturnAllGroups()
        {
            var response = await _client.FindAllGroupsOnWorkspaceAsync(_workspaceId);
            response.IsSuccessful.Should().BeTrue();
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCountGreaterThan(0);
            foreach (var group in response.Data)
            {
                group.Should().NotBeNull();
                group.Id.Should().NotBeEmpty();
                group.WorkspaceId.Should().Be(_workspaceId);
            }
        }

     
    }
}