namespace Clockify.Net.Models.TimeOff;

public class ChangeTimeOffRequestStatusRequest
{
	public ChangeTimeOffRequestStatusRequest()
	{
	}

	/// <summary>
	///   For <see cref="ClockifyClient.ChangeTimeOffRequestStatusAsync" />
	/// </summary>
	public ChangeTimeOffRequestStatusRequest(TimeOffRequestStatusEnum status)
	{
		Status = status;
	}

	public string? Note { get; set; }
	public TimeOffRequestStatusEnum? Status { get; set; }
}