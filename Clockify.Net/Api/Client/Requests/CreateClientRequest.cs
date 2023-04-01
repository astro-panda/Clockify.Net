namespace Clockify.Net.Api.Client.Requests; 

public sealed class CreateClientRequest
{
    public string? Address { get; set; }
    public string? Email { get; set; }
    public required string Name { get; set; }
    public string? Note { get; set; }
}