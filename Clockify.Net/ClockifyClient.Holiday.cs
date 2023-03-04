using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Holidays;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Get all Time Off requests
        /// </summary>
        public async Task<Response<IEnumerable<HolidaysDto>>> GetHolidaysOnWorkspace(string workspaceId, GetHolidaysRequestParams parameters = null)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/holidays");
            
            if(parameters != null){
                request.AddJsonBody<GetHolidaysRequestParams>(parameters);
            }

            return Response<IEnumerable<HolidaysDto>>.FromRestResponse(await _ptoClient.ExecuteGetAsync<IEnumerable<HolidaysDto>>(request).ConfigureAwait(false));
        }
    }
}
