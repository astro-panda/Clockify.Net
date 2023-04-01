namespace Clockify.Net.Api.Balance.Requests; 

public record GetBalanceRequest
{
	public int? Page { get; set; }
	public int? PageSize { get; set; }
	public string? Sort { get; set; }
	public string? SortOrder { get; set; } 
}