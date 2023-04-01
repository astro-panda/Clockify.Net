namespace Clockify.Net.Api.Common.Requests; 

public abstract class ColumnPagedRequest {
	public int? Page { get; set; }
	public int? PageSize { get; set; }
	public string? SortColumn { get; set; }
	public string? SortOrder { get; set; } 
}