using System.Collections.Generic;

namespace Clockify.Net.Models.Templates
{
    public class TemplateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ProjectsTaskTupleDto> ProjectsAndTasks { get; set; }
        public string UserId { get; set; }
        public string WorkspaceId { get; set; }
    }
}