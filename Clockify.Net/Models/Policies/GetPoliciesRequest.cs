using Clockify.Net.Extensions;
using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models.Policies;

public class GetPoliciesRequest
{
	public int? Page { get; set; } // default: 1

	private int? _pageSize;
	public int? PageSize
	{
		get => _pageSize;
		set => _pageSize = value?.Clamp(0, 200);
	} // default: 50
	public string? Name { get; set; }
	public StatusEnum? Status { get; set; }
}