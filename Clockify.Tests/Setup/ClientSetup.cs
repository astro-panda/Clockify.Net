using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Clients;
using Clockify.Net.Models.HourlyRates;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Tags;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Clockify.Tests.Setup {
	public class ClientSetup : IAsyncDisposable {
		private readonly ClockifyClient _client;
		private readonly string _workspaceName;
		private string _id = string.Empty;

		public ClientSetup(ClockifyClient client, string workspaceName) {
			this._client = client;
			_workspaceName = workspaceName;
		}

		public async Task<ClientDto> SetupAsync([CallerMemberName] string callerName = "") {
			var request = new ClientRequest() {
				Name = $"Setup client {Guid.NewGuid()}: {callerName}",
			};

			// Tag cannot be longer than 100
			if (request.Name.Length > 100) request.Name = request.Name.Substring(0, 99);
			
			var response = await _client.CreateClientAsync(_workspaceName, request);
			response.IsSuccessful.Should().BeTrue();
			response.Data.Should().NotBeNull();

			_id = response.Data.Id;
			return response.Data;
		}


		public async ValueTask DisposeAsync() {
			try {
				await _client.DeleteClientAsync(_workspaceName, _id);
			}
			catch (HttpRequestException) {
				TestContext.WriteLine($"Deleting client {_id} failed.");
			}
		}
	}
}