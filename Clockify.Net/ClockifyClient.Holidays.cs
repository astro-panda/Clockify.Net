﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Holiday;
using RestSharp;

namespace Clockify.Net;

public partial class ClockifyClient
{
    /// <summary>
    /// Get all Holidays
    /// </summary>
    public async Task<Response<IEnumerable<HolidayDto>>> GetHolidaysAsync(string workspaceId, GetHolidaysRequest? getHolidaysRequest = null)
    {
        var request = new RestRequest($"workspaces/{workspaceId}/holidays");
        if (getHolidaysRequest?.AssignedTo != null)
            request.AddQueryParameter("assigned-to", getHolidaysRequest.AssignedTo);
        return Response<IEnumerable<HolidayDto>>.FromRestResponse(await _client.ExecuteGetAsync<IEnumerable<HolidayDto>>(request).ConfigureAwait(false));
    }
    
    /// <summary>
    /// Add a new holiday to workspace.
    /// </summary>
    public async Task<Response<HolidayDto>> CreateHolidayAsync(string workspaceId, HolidayRequest holiday)
    {
        if (holiday == null) throw new ArgumentNullException(nameof(holiday));
        if (holiday.DatePeriod == null) throw new ArgumentNullException(nameof(holiday.DatePeriod));
        if (holiday.Name == null) throw new ArgumentNullException(nameof(holiday.Name));
        if ((holiday.UserGroups?.Ids == null || !holiday.UserGroups.Ids.Any()) &&
            (holiday.Users?.Ids == null || !holiday.Users.Ids.Any()))
        {
            throw new ArgumentOutOfRangeException("At least one user or user group must be assigned");
        }

        var request = new RestRequest($"workspaces/{workspaceId}/holidays", Method.Post);
        request.AddJsonBody(holiday);
        return Response<HolidayDto>.FromRestResponse(await _client.ExecuteAsync<HolidayDto>(request).ConfigureAwait(false));
    }

    /// <summary>
    /// Get holiday in specific period.
    /// </summary>
    public async Task<Response> GetHolidayInSpecificPeriodAsync(string workspaceId, GetHolidaysRequest holiday)
    {
        if (holiday == null) throw new ArgumentNullException(nameof(holiday));
        if (holiday.AssignedTo == null) throw new ArgumentNullException(nameof(holiday.AssignedTo));
        if (holiday.Start is not { } holidayStart) throw new ArgumentNullException(nameof(holiday.Start));
        if (holiday.End is not { } holidayEnd) throw new ArgumentNullException(nameof(holiday.End));
        
        var request = new RestRequest($"workspaces/{workspaceId}/holidays/in-period");
        request.AddQueryParameter("assigned-to", holiday.AssignedTo);
        request.AddQueryParameter("start", holidayStart.ToUniversalTime().ToString("o"));
        request.AddQueryParameter("end", holidayEnd.ToUniversalTime().ToString("o"));
        return Response.FromRestResponse(await _client.ExecuteGetAsync(request).ConfigureAwait(false));
    }
    
    /// <summary>
    /// Delete holiday with Id.
    /// </summary>
    public async Task<Response> DeleteHolidayAsync(string workspaceId, string holidayId)
    {
        var request = new RestRequest($"workspaces/{workspaceId}/holidays/{holidayId}");
        return Response.FromRestResponse(await _client.ExecuteAsync(request, Method.Delete).ConfigureAwait(false));
    }
    
    /// <summary>
    /// Update holiday on workspace.
    /// </summary>
    public async Task<Response<HolidayDto>> UpdateHolidayAsync(string workspaceId, string holidayId, HolidayRequest holiday)
    {
        if (holiday == null) throw new ArgumentNullException(nameof(holiday));
        if (holiday.DatePeriod == null) throw new ArgumentNullException(nameof(holiday.DatePeriod));
        if (holiday.DatePeriod.EndDate == null) throw new ArgumentNullException(nameof(holiday.DatePeriod.EndDate));
        if (holiday.DatePeriod.StartDate == null) throw new ArgumentNullException(nameof(holiday.DatePeriod.StartDate));
        if (holiday.Name == null) throw new ArgumentNullException(nameof(holiday.Name));
        if (holiday.OccursAnnually == null) throw new ArgumentNullException(nameof(holiday.OccursAnnually));
        if ((holiday.UserGroups?.Ids == null || !holiday.UserGroups.Ids.Any()) &&
            (holiday.Users?.Ids == null || !holiday.Users.Ids.Any()))
        {
            throw new ArgumentOutOfRangeException("At least one user or user group must be assigned");
        }

        var request = new RestRequest($"workspaces/{workspaceId}/holidays/{holidayId}");
        request.AddJsonBody(holiday);
        return Response<HolidayDto>.FromRestResponse(await _client.ExecuteAsync<HolidayDto>(request, Method.Put).ConfigureAwait(false));
    }
}