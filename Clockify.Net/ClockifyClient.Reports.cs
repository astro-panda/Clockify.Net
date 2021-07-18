using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models.Reports;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Find workspaces for currently logged in user
        /// </summary>
        public Task<IRestResponse<List<SummaryReportDto>>> GetSummaryReportAsync(string workspaceId, SummaryReportRequest summaryReportRequest)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/reports/summary", Method.POST);
            request.AddJsonBody(summaryReportRequest);

            return _reportsClient.ExecuteGetAsync<List<SummaryReportDto>>(request);
        }

        /// <summary>
        /// Creates new workspace.
        /// </summary>
        public Task<IRestResponse<DetailedReportDto>> GetDetailedReportAsync(string workspaceId, DetailedReportRequest detailedReportRequest)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/reports/detailed", Method.POST);
            request.AddJsonBody(detailedReportRequest);
            
            return _reportsClient.ExecutePostAsync<DetailedReportDto>(request);
        }

        /// <summary>
        /// Adds a user to workspace.
        /// </summary>
        public Task<IRestResponse<List<WeeklyReportDto>>> GetWeeklyReportAsync(string workspaceId)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/reports/weekly", Method.POST);
            //request.AddJsonBody(requestBody);

            return _reportsClient.ExecuteAsync<List<WeeklyReportDto>>(request, Method.POST);
        }
    }
}
