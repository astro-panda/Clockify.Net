using System.Collections.Generic;

namespace Clockify.Net.Models.Balance;

public class BalancesDto
{
	public IEnumerable<BalanceDtoV1> Balances { get; set; }
	public int Count { get; set; }
}