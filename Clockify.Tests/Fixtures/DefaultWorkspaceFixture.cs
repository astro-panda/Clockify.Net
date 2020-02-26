using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Clockify.Net.Models.Workspaces;
using RestSharp;

namespace Clockify.Tests.Fixtures
{
    public class DefaultWorkspaceFixture
    {
        public static string DefaultWorkspaceId;
        private const string BaseUrl = "https://api.clockify.me/api/v1";
        private const string DefaultWorkspaceName = "Default Test Workspace";
        public static void Setup()
        {
			// RestClient setup
	        var client = new RestClient();
			var apiKey = Environment.GetEnvironmentVariable("CAPI_KEY");
			client.AddDefaultHeader("X-Api-Key", apiKey);

			var workspaces = client.Get<List<WorkspaceDto>>(new RestRequest(BaseUrl + "/workspaces"));
			var defaultWorkspace = workspaces.Data.SingleOrDefault(w => w.Name == DefaultWorkspaceName);
			if (defaultWorkspace != null)
				DefaultWorkspaceId = defaultWorkspace.Id;
			else
				CreateWorkspace(client);
        }

        private static void CreateWorkspace(RestClient client) {
	        //Creating new workspace
	        var createWorkspaceRequest = new RestRequest(BaseUrl + "/workspaces");
	        createWorkspaceRequest.AddJsonBody(new { name =  DefaultWorkspaceName});
	        var response = client.Post<WorkspaceDto>(createWorkspaceRequest);
	        // Checking
	        if (!response.IsSuccessful &&
	            !response.Content.Contains("workspace with name 'Default Test Workspace' already exists."))
		        throw new HttpRequestException($"Creating default workspace failed: {response.Content}");
	        DefaultWorkspaceId = response.Data.Id;
        }
    }
}