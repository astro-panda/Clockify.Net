namespace Clockify.Net.Models.Tags; 

public class TagUpdateRequest 
{
	public string Name { get; set; }
	public bool? Archived { get; set; }    
}