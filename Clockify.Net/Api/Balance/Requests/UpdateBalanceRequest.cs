using System.Collections.Generic;

namespace Clockify.Net.Api.Balance.Requests;

public record UpdateBalanceRequest {
	public required IEnumerable<string> UserIds { get; init; }
	public required double Value { get; init; }
	public string? Note { get; set; }
}