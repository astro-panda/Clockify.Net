using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.TimeOff;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Get all Time Off requests
        /// </summary>
        public async Task<Response<TimeOffRequestResponse>> GetAllTimeOffRequests(string workspaceId, TimeOffEndpointRequest parameters = null)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/requests");
            
            if(parameters != null){
                request.AddJsonBody<TimeOffEndpointRequest>(parameters);
            }

            return Response<TimeOffRequestResponse>.FromRestResponse(await _ptoClient.ExecutePostAsync<TimeOffRequestResponse>(request).ConfigureAwait(false));
        }
    }
}
