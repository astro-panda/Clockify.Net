namespace Clockify.Net.Api.Common.Requests; 

public abstract class PagedRequest {
	public int? Page { get; set; }
	public int? PageSize { get; set; }
	public string? Sort { get; set; }
	public string? SortOrder { get; set; } 
}