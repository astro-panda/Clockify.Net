using System.Collections.Generic;
using Clockify.Net.Models.Interfaces;

namespace Clockify.Net.Models.Balance;

public class BalancesDto : IHasCount
{
	public IEnumerable<BalanceDtoV1> Balances { get; set; }
	public int Count { get; set; }
}