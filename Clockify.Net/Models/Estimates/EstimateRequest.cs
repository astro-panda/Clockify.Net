namespace Clockify.Net.Models.Estimates; 

public class EstimateRequest
{
    public int? Estimate { get; set; }

    public EstimateType Type { get; set; }
}