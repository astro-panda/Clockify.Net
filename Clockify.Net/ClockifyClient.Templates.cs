using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Templates;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Get templates for current user on specified workspace. See Clockify docs for query params explanation.
        /// </summary>
        public async Task<Response<List<TemplateDto>>> FindAllTemplatesOnWorkspaceAsync(
            string workspaceId,
            string name = null,
            bool cleansed = false,
            bool hydrated = false,
            int page = 1,
            int pageSize = 1)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/templates");

            if (name != null) { request.AddQueryParameter(nameof(name), name); }
            request.AddQueryParameter(nameof(cleansed), cleansed.ToString());
            request.AddQueryParameter(nameof(hydrated), hydrated.ToString());
            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter("page-size", pageSize.ToString());

            return Response<List<TemplateDto>>.FromRestResponse(await _client.ExecuteGetAsync<List<TemplateDto>>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Get template from workspace. See Clockify docs for query params explanation.
        /// </summary>
        public async Task<Response<TemplateDto>> GetTemplateAsync(
            string workspaceId,
            string templateId,
            bool cleansed = false,
            bool hydrated = false)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/templates/{templateId}");
            request.AddQueryParameter(nameof(cleansed), cleansed.ToString());
            request.AddQueryParameter(nameof(hydrated), hydrated.ToString());
            return Response<TemplateDto>.FromRestResponse(await _client.ExecuteGetAsync<TemplateDto>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Save templates to workspace.
        /// </summary>
        public async Task<Response<List<TemplateDto>>> CreateTemplatesAsync(string workspaceId, params TemplateRequest[] projectRequests)
        {
            if (projectRequests == null) { throw new ArgumentNullException(nameof(projectRequests)); }

            // todo: this nested foreach needs work
            foreach (var templateRequest in projectRequests)
            {
                if (templateRequest.Name == null) { throw new ArgumentNullException(nameof(templateRequest.Name)); }
                if (templateRequest.ProjectsAndTasks == null) { throw new ArgumentNullException(nameof(templateRequest.ProjectsAndTasks)); }

                foreach (var projectsAndTask in templateRequest.ProjectsAndTasks)
                {
                    if (projectsAndTask.ProjectId == null) { throw new ArgumentNullException(nameof(projectsAndTask.ProjectId)); }
                    if (projectsAndTask.TaskId == null) { throw new ArgumentNullException(nameof(projectsAndTask.TaskId)); }
                }
            }

            var request = new RestRequest($"workspaces/{workspaceId}/templates", Method.Post);
            request.AddJsonBody(projectRequests);
            return Response<List<TemplateDto>>.FromRestResponse(await _client.ExecutePostAsync<List<TemplateDto>>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Delete template with id.
        /// </summary>
        public async Task<Response<TemplateDto>> DeleteTemplateAsync(string workspaceId, string templateId)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/templates/{templateId}", Method.Delete);
            return Response<TemplateDto>.FromRestResponse(await _client.ExecuteAsync<TemplateDto>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Updates template with id.
        /// </summary>
        public async Task<Response<TemplateDto>> UpdateTemplateAsync(
            string workspaceId,
            string timeEntryId,
            TemplatePatchRequest templatePatchRequest)
        {
            if (templatePatchRequest == null) { throw new ArgumentNullException(nameof(templatePatchRequest)); }
            if (templatePatchRequest.Name == null) { throw new ArgumentNullException(nameof(templatePatchRequest.Name)); }

            var request = new RestRequest($"workspaces/{workspaceId}/templates/{timeEntryId}", Method.Patch);
            request.AddJsonBody(templatePatchRequest);
            return Response<TemplateDto>.FromRestResponse(await _client.ExecuteAsync<TemplateDto>(request).ConfigureAwait(false));
        }
    }
}
