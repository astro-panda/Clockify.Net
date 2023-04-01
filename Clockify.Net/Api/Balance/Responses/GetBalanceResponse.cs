using System.Collections.Generic;

namespace Clockify.Net.Api.Balance.Responses; 

public class GetBalanceResponse
{
	public IEnumerable<BalanceDto> Balances { get; set; }
	public int Count { get; set; }
}