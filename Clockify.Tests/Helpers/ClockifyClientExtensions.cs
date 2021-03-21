using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Projects;
using RestSharp;

namespace Clockify.Tests.Helpers {
	public static class ClockifyClientExtensions {
		public static async Task<IRestResponse> ArchiveAndDeleteProject(this ClockifyClient client, string workspaceId, string projectId) 
		{
			var projectUpdateRequest = new ProjectUpdateRequest {Archived = true};
			var archiveProjectResponse = await client.UpdateProjectAsync(workspaceId, projectId, projectUpdateRequest);
			if (!archiveProjectResponse.IsSuccessful) return archiveProjectResponse;
			return await client.DeleteProjectAsync(workspaceId, projectId);
		}
	}
}