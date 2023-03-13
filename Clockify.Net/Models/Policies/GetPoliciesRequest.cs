using System;
using Clockify.Net.Models.Enums;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Policies;

public class GetPoliciesRequest
{
	public int? Page { get; set; } // default: 1

	private int? _pageSize;
	[JsonProperty("page-size")]
	public int? PageSize
	{
		get => _pageSize;
		set => _pageSize = value == null ? null : Math.Clamp((int)value, 0, 200);
	} // default: 50
	public string Name { get; set; }
	public StatusEnum? Status { get; set; }
}