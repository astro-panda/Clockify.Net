using System;
using System.Collections.Generic;
using System.Text;

namespace Clockify.Net.Clients;

/// <summary>
/// The core Clockify client
/// </summary>
public interface IClockifyClient
{
    /// <summary>
    /// Access to Experimental features of the Clockify API
    /// </summary>
    public IClockifyExperimentalClient Experimental { get; }

    /// <summary>
    /// Access to Reporting features of the Clockify API
    /// </summary>
    public IClockifyReportsClient Reports { get; }

    /// <summary>
    /// Access to Paid Time Off features of the Clockify API
    /// </summary>
    public IClockifyPTOClient PaidTimeOff { get; }
}
