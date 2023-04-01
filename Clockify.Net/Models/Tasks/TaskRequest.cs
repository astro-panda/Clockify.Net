using System.Collections.Generic;

namespace Clockify.Net.Models.Tasks; 

public class TaskRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<string> AssigneeIds { get; set; }
    public string Estimate { get; set; }
    public string Status { get; set; }
}