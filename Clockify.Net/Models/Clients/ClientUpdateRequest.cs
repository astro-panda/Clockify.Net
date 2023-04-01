namespace Clockify.Net.Models.Clients; 

public class ClientUpdateRequest {
	public string Name { get; set; }
	public bool? Archived { get; set; }
	public string Note { get; set; }
}