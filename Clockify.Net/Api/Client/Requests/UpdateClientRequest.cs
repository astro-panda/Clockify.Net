namespace Clockify.Net.Api.Client.Requests; 

public sealed class UpdateClientRequest {
	public string? Address { get; set; }
	public bool? Archived { get; set; }
	public string? Email { get; set; }
	public string? Id { get; set; }
	public required string Name { get; set; }
	public string? Note { get; set; }
}