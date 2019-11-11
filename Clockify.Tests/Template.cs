using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Workspaces;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests {
	public class Template {
		private readonly ClockifyClient _client;
		private string _workspaceId;

		public Template() {
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

		//[Test]
		public async Task MethodName_ParamsOrConditions_ShouldDoSomething() {
			// Something to test

			// Fluent Assert
		}

	}
}