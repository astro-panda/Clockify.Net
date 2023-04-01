using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models.Policies; 

public class ChangePolicyStatusRequest
{
	public ChangePolicyStatusRequest()
	{
	}

	/// <summary>
	/// For <see cref="ClockifyClient.ChangePolicyStatusAsync"/>
	/// </summary>
	/// <param name="status"></param>
	public ChangePolicyStatusRequest(StatusEnum status)
	{
		Status = status;
	}
	
	public StatusEnum? Status { get; set; }
}