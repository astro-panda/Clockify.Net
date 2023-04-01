using Clockify.Net.Api.Common.Requests;

namespace Clockify.Net.Api.Client.Requests;

public sealed class GetClientsRequest : ColumnPagedRequest {
	public string? Name { get; set; }
	public bool? Archived { get; set; }
}