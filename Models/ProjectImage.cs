namespace ZenithCMS.Models
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ProjectDetailId { get; set; }
        public ProjectDetail ProjectDetail { get; set; }
    }
}
