using System.ComponentModel.DataAnnotations;

namespace ZenithCMS.Models
{
    public class ServicePage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceName { get; set; }

        [Required]
        [StringLength(500)]
        public string ServiceDescription { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}