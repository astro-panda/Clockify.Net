using Clockify.Net.Api.Common.Requests;
using Clockify.Net.Api.User.Responses;

namespace Clockify.Net.Api.User.Requests;

public class GetAllUserRequest : ColumnPagedRequest {
	public string? Email { get; set; }
	public string? ProjectId { get; set; }
	public UserStatus? Status { get; set; }
	public string? Name { get; set; }
	public string? Memberships { get; set; }
}