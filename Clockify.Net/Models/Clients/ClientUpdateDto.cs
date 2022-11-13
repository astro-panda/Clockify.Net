namespace Clockify.Net.Models.Clients
{
    public class ClientUpdateDto
    {
        public bool? Archived { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Note { get; set; }
        public string? WorkspaceId { get; set; }
    }
}
