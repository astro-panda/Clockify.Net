namespace Clockify.Net.Api.Balance.Responses; 

public class BalanceDto
{
	public double Balance { get; set; }
	public string Id { get; set; }
	public double NegativeBalanceAmount { get; set; }
	public bool NegativeBalanceLimit { get; set; }
	public bool PolicyArchived { get; set; }
	public string PolicyId { get; set; }
	public string PolicyName { get; set; }
	public string PolicyTimeUnit { get; set; }
	public double Total { get; set; }
	public double Used { get; set; }
	public string UserId { get; set; }
	public string UserName { get; set; }
	public string WorkspaceId { get; set; }
}