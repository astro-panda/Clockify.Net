using System;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Balance;

public class BalanceRequest
{
	public int? Page { get; set; } // default: 1

	private int? _pageSize;
	[JsonProperty("page-size")]
	public int? PageSize
	{
		get => _pageSize;
		set => _pageSize = value == null ? null : Math.Clamp((int)value, 0, 200);
	} // default: 50

	public string Sort { get; set; } // default: USER
	[JsonProperty("sort-order")]
	public string SortOrder { get; set; } // default: ASCENDING
}