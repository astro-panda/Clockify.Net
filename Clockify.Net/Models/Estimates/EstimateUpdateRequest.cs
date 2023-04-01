namespace Clockify.Net.Models.Estimates; 

public class EstimateUpdateRequest
{
    public TimeEstimateRequest? TimeEstimate { get; set; }
    public BudgetEstimateRequest? BudgetEstimate { get; set; }
}