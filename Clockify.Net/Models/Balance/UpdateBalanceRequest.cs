using System;
using System.Collections.Generic;

namespace Clockify.Net.Models.Balance;

public class UpdateBalanceRequest
{
	public string? Note { get; set; }
	public IEnumerable<string>? UserIds { get; set; }

	private double? _value;
	public double? Value
	{
		get => _value;
		set => _value = value == null ? value : Math.Clamp((double)value, -10000, 10000);
	}
}