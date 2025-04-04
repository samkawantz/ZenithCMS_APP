using Microsoft.Identity.Client;

namespace ZenithCMS.Models
{
    public class ProjectDetail
    {
        public int Id { get; set; }
        public string ProjectSummary { get; set; }
        public string ClientName { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Website { get; set; }
        public List<ProjectImage> Images { get; set; } = new();
    }
}
