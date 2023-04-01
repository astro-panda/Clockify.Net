namespace Clockify.Net.Api.Client.Responses; 

public record UpdateClientResponse
{
    public bool Archived { get; set; }
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Note { get; set; }
    public string? WorkspaceId { get; set; }
}