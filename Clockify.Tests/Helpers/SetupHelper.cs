using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Workspaces;
using RestSharp;

namespace Clockify.Tests.Helpers {
	public class SetupHelper {
		/// <summary>
		/// Creates or finds workspace and return workspace id
		/// </summary>
		public static async Task<string> CreateOrFindWorkspaceAsync(ClockifyClient client, string workspaceName) 
		{
			
			var workspaceResponse = await client.CreateWorkspaceAsync(new WorkspaceRequest {Name = workspaceName});
			string workspaceId;
			// workspaceResponse.IsSuccessful.Should().BeTrue();

			if (workspaceResponse.IsSuccessful) 
			{
				workspaceId = workspaceResponse.Data.Id;
			}
			else if (WorkspaceAlreadyExist(workspaceResponse)) 
			{
				var workspacesResponse = await client.GetWorkspacesAsync();
				var workspace = workspacesResponse.Data.SingleOrDefault(dto => dto.Name == workspaceName);
				if (workspace == null)
					throw new NullReferenceException($"Workspace {workspaceName} do not exist.");
				return workspace.Id;
			}
			else 
			{
				throw new InvalidOperationException($"Cannot create or find workspace: {workspaceResponse.Content}");
			}


			return workspaceId;
		}

		public async Task<string> CreateOrFindWorkspaceAsync(string workspaceName) 
		{
			return await CreateOrFindWorkspaceAsync(new ClockifyClient(), workspaceName);
		}

		private static bool WorkspaceAlreadyExist(IRestResponse<WorkspaceDto> workspaceResponse) 
		{
			return workspaceResponse.StatusCode == HttpStatusCode.BadRequest && 
			       workspaceResponse.Content.Contains("already exist");
		}
	}
}