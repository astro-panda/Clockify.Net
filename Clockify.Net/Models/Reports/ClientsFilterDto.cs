using System.Collections.Generic;

namespace Clockify.Net.Models.Reports; 

public class ClientsFilterDto
{
    public List<string> Ids { get; set; }
    public ContainsType Contains {get; set;}
    public StatusType Status { get; set; }
}