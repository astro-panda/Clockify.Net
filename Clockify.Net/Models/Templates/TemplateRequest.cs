using System.Collections.Generic;

namespace Clockify.Net.Models.Templates
{
    public class TemplateRequest
    {
        public string Name { get; set; }

        public List<ProjectsTaskTupleRequest> ProjectsAndTasks { get; set; }
    }
}