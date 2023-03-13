using System.Collections.Generic;
using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models;

public class ContainsFilter
{
	public ContainsEnum Contains { get; set; }
	public IEnumerable<string> Ids { get; set; }
	public StatusEnum Status { get; set; }
}