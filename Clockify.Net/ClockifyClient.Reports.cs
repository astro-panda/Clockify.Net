using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Reports;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Obtains the requested Detailed Report.
        /// </summary>
        public async Task<Response<DetailedReportDto>> GetDetailedReportAsync(string workspaceId, DetailedReportRequest detailedReportRequest)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/reports/detailed", Method.Post);
            request.AddJsonBody(detailedReportRequest);

            return Response<DetailedReportDto>.FromRestResponse(await _reportsClient.ExecutePostAsync<DetailedReportDto>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Obtains the requested Summary Report.
        /// </summary>
        public async Task<Response<SummaryReportDto>> GetSummaryReportAsync(string workspaceId, SummaryReportRequest summaryReportRequest)
        {
            if (summaryReportRequest.DateRangeStart == null) { throw new ArgumentNullException(nameof(summaryReportRequest.DateRangeStart)); }
            if (summaryReportRequest.DateRangeEnd == null) { throw new ArgumentNullException(nameof(summaryReportRequest.DateRangeStart)); }
            if (summaryReportRequest.SummaryFilter == null) { throw new ArgumentNullException(nameof(summaryReportRequest.SummaryFilter)); }
            
            var request = new RestRequest($"workspaces/{workspaceId}/reports/summary", Method.Post);
            request.AddJsonBody(summaryReportRequest);
            
            return Response<SummaryReportDto>.FromRestResponse(await _reportsClient.ExecuteAsync<SummaryReportDto>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Obtains the requested Weekly Report.
        /// </summary>
        public async Task<Response<WeeklyReportDto>> GetWeeklyReportAsync(string workspaceId, WeeklyReportRequest weeklyReportRequest)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/reports/weekly", Method.Post);
            request.AddJsonBody(weeklyReportRequest);

            return Response<WeeklyReportDto>.FromRestResponse(await _reportsClient.ExecuteAsync<WeeklyReportDto>(request, Method.Post).ConfigureAwait(false));
        }
    }
}
