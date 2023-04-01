using System.Collections.Generic;

namespace Clockify.Net.Api.Balance.Responses; 

public record GetBalanceResponse
{
	public required IEnumerable<BalanceDetails> Balances { get; set; }
	public int Count { get; set; }
}