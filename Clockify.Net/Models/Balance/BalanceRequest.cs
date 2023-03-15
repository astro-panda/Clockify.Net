using Clockify.Net.Extensions;

namespace Clockify.Net.Models.Balance;

public class BalanceRequest
{
	public int? Page { get; set; } // default: 1

	private int? _pageSize;
	public int? PageSize
	{
		get => _pageSize;
		set => _pageSize = value?.Clamp(0, 200);
	} // default: 50

	public string? Sort { get; set; } // default: USER
	public string? SortOrder { get; set; } // default: ASCENDING
}