using System.Collections.Generic;

namespace Clockify.Net.Api.Balance.Requests;

public class UpdateBalanceRequest {
	public required IEnumerable<string> UserIds { get; set; }
	public required double Value { get; set; }
	public string? Note { get; set; }
}