using Clockify.Net.Extensions;
using Clockify.Net.Models.Enums;

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

	public SortEnum? Sort { get; set; }
	public SortOrderEnum? SortOrder { get; set; }
}