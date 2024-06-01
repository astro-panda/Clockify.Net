namespace Clockify.Net.Models.Clients
{
    public class ClientDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? WorkspaceId { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? CurrencyCode { get; set; }
        public string? CurrencyId { get; set; }
        public string? Note { get; set; }
        public bool Archived { get; set; }
    }
}