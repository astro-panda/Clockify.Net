namespace Clockify.Net.Api.Client.Responses; 

public record ClientDetails
{
    public string? Address { get; set; }
    public bool? Archived { get; set; }
    public string? Email { get; set; }
    public required string Id { get; init; }
    public required string Name { get; init; }
    public string? Note { get; set; }
    public string? WorkspaceId { get; set; }
}