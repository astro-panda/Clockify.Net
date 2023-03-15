using System.Collections.Generic;
using Clockify.Net.Extensions;

namespace Clockify.Net.Models.Balance;

public class UpdateBalanceRequest
{
	public UpdateBalanceRequest()
	{
	}

	/// <summary>
	/// For <see cref="ClockifyClient.UpdateBalanceAsync"/>
	/// </summary>
	public UpdateBalanceRequest(IEnumerable<string> userIds, double value)
	{
		UserIds = userIds;
		Value = value;
	}
	
	public string? Note { get; set; }
	public IEnumerable<string>? UserIds { get; set; }

	private double? _value;
	public double? Value
	{
		get => _value;
		set => _value = value?.Clamp(-10000, 10000);
	}
}