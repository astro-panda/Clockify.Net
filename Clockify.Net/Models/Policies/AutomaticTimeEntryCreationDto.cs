using Clockify.Net.Models.Templates;

namespace Clockify.Net.Models.Policies;

public class AutomaticTimeEntryCreationDto
{
	public ProjectsTaskTupleDto DefaultEntities { get; set; }
	public bool Enabled { get; set; }
}