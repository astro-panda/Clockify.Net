using RestSharp;

namespace Clockify.Net.Api.Common.Requests; 

public static class RestRequestExtensions {
	public static void AddPagedQuery(this RestRequest request, PagedRequest pagedRequest) {
		if (pagedRequest.Page is { } balancePage) request.AddQueryParameter("page", balancePage);
		if (pagedRequest.PageSize is { } balancePageSize) request.AddQueryParameter("page-size", balancePageSize);
		if (pagedRequest.Sort is null) request.AddQueryParameter("sort", pagedRequest.Sort);
		if (pagedRequest.SortOrder is null) request.AddQueryParameter("sort-order", pagedRequest.SortOrder);
	}

	public static void AddPagedQuery(this RestRequest request, ColumnPagedRequest pagedRequest) {
		if (pagedRequest.Page is { } balancePage) request.AddQueryParameter("page", balancePage);
		if (pagedRequest.PageSize is { } balancePageSize) request.AddQueryParameter("page-size", balancePageSize);
		if (pagedRequest.SortColumn is null) request.AddQueryParameter("sort-column", pagedRequest.SortColumn);
		if (pagedRequest.SortOrder is null) request.AddQueryParameter("sort-order", pagedRequest.SortOrder);
	}
}