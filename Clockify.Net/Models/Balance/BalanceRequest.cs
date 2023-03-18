using Clockify.Net.Extensions;

namespace Clockify.Net.Models.Balance;

public class BalanceRequest
{
	public int? Page { get; set; }

	private int? _pageSize;
	public int? PageSize
	{
		get => _pageSize;
		set => _pageSize = value?.Clamp(0, 200);
	}

	public string? Sort { get; set; }
	public string? SortOrder { get; set; } 
}