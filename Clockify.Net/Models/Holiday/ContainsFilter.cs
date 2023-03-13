using System.Collections.Generic;

namespace Clockify.Net.Models.Holiday;

public class ContainsFilter
{
	public ContainsEnum Contains { get; set; }
	public IEnumerable<string> Ids { get; set; }
	public string Status { get; set; }
}