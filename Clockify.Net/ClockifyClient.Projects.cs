using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Estimates;
using Clockify.Net.Models.Memberships;
using Clockify.Net.Models.Projects;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Find projects on workspace. See Clockify docs for query params explanation.
        /// </summary>
        public async Task<Response<List<ProjectDtoImpl>>> FindAllProjectsOnWorkspaceAsync(string workspaceId,
            bool? archived = null,
            string name = null,
            bool? billable = null,
            string[] clients = null,
            bool? containsClient = null,
            string clientStatus = null,
            string[] users = null,
            bool? containsUsers = null,
            string userStatus = null,
            bool? isTemplate = null,
            string sortColumn = null,
            string sortOrder = null,
            int page = 1,
            int pageSize = 50)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/projects");
            if (archived != null) { request.AddQueryParameter(nameof(archived), archived.ToString()); }
            if (name != null) { request.AddQueryParameter(nameof(name), name); }
            if (billable != null) { request.AddQueryParameter(nameof(billable), billable.ToString()); }
            if (clients != null && clients.Length > 0)
            {
                request.AddQueryParameter(nameof(clients), string.Join(",", clients));
            }
            if (containsClient != null) { request.AddQueryParameter("contains-client", containsClient.ToString()); }
            if (!string.IsNullOrEmpty(clientStatus)) { request.AddQueryParameter("client-status", clientStatus); }
            if (users != null && users.Length > 0)
            {
                request.AddQueryParameter(nameof(users), string.Join(",", users));
            }
            if (containsUsers != null) { request.AddQueryParameter("contains-users", containsUsers.ToString()); }
            if (!string.IsNullOrEmpty(userStatus)) { request.AddQueryParameter("user-status", userStatus); }
            if (isTemplate != null) { request.AddQueryParameter("is-template", isTemplate.ToString()); }
            if (!string.IsNullOrEmpty(sortColumn)) { request.AddQueryParameter("sort-column", sortColumn); }
            if (!string.IsNullOrEmpty(sortOrder)) { request.AddQueryParameter("sort-order", sortOrder); }

            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter("page-size", pageSize.ToString());

            return Response<List<ProjectDtoImpl>>.FromRestResponse(await _client.ExecuteGetAsync<List<ProjectDtoImpl>>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Add a new project to workspace.
        /// </summary>
        public async Task<Response<ProjectDtoImpl>> CreateProjectAsync(string workspaceId, ProjectRequest projectRequest)
        {
            if (projectRequest == null) { throw new ArgumentNullException(nameof(projectRequest)); }
            if (projectRequest.Name == null) throw new ArgumentNullException(nameof(projectRequest.Name));
            if (projectRequest.Color == null) throw new ArgumentNullException(nameof(projectRequest.Color));
            if (projectRequest.Estimate != null && !Enum.IsDefined(typeof(EstimateType), projectRequest.Estimate.Type))
                throw new ArgumentOutOfRangeException(nameof(projectRequest.Estimate.Type));

            var request = new RestRequest($"workspaces/{workspaceId}/projects", Method.Post);
            request.AddJsonBody(projectRequest);
            return Response<ProjectDtoImpl>.FromRestResponse(await _client.ExecuteAsync<ProjectDtoImpl>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Delete project with Id.
        /// </summary>
        public async Task<Response> DeleteProjectAsync(string workspaceId, string id)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/projects/{id}");
            return Response.FromRestResponse(await _client.ExecuteAsync(request, Method.Delete).ConfigureAwait(false));
        }

        /// <summary>
        /// Find project with Id.
        /// </summary>
        public async Task<Response> FindProjectByIdAsync(string workspaceId, string id)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/projects/{id}");
            return Response.FromRestResponse(await _experimentalClient.ExecuteAsync(request, Method.Get).ConfigureAwait(false));
        }
        
        /// <summary>
        /// Update project on workspace.
        /// </summary>
        public async Task<Response<ProjectDtoImpl>> UpdateProjectAsync(string workspaceId, string projectId, ProjectUpdateRequest project)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}");
            request.AddJsonBody(project);
            return Response<ProjectDtoImpl>.FromRestResponse(await _client.ExecuteAsync<ProjectDtoImpl>(request, Method.Put).ConfigureAwait(false));
        }
        
        /// <summary>
        /// Update estimates on a project.
        /// </summary>
        public async Task<Response<ProjectDtoImpl>> UpdateProjectEstimatesAsync(string workspaceId, string projectId, EstimateUpdateRequest estimateUpdateRequest)
        {
            if (estimateUpdateRequest.BudgetEstimate?.Active == true &&
                estimateUpdateRequest.TimeEstimate?.Active == true) throw new ArgumentException($"{nameof(BudgetEstimateRequest)} and {nameof(TimeEstimateRequest)} cannot both be active.");
            
            var request = new RestRequest($"/workspaces/{workspaceId}/projects/{projectId}/estimate");
            request.AddJsonBody(estimateUpdateRequest);
            return Response<ProjectDtoImpl>.FromRestResponse(await _client.ExecuteAsync<ProjectDtoImpl>(request, Method.Patch).ConfigureAwait(false));
        }
        
        /// <summary>
        /// Update memberships on a project.
        /// </summary>
        public async Task<Response<ProjectDtoImpl>> UpdateProjectMembershipsAsync(string workspaceId, string projectId, UpdateMembershipsRequest updateMembershipsRequest)
        {
            var request = new RestRequest($"/workspaces/{workspaceId}/projects/{projectId}/memberships");
            request.AddJsonBody(updateMembershipsRequest);
            return Response<ProjectDtoImpl>.FromRestResponse(await _client.ExecuteAsync<ProjectDtoImpl>(request, Method.Patch).ConfigureAwait(false));
        }
    }
}
