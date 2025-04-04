using System.ComponentModel.DataAnnotations;

namespace ZenithCMS.Models
{
    public class AboutPage
    {

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string WhoWeAre { get; set; } = string.Empty;


        [Required]
        [StringLength(500)]
        public string AboutZMC { get; set; } = string.Empty;


        [Required]
        [StringLength(500)]
        public string Vision { get; set; } = string.Empty;


        [Required]
        [StringLength(500)]
        public string Mission { get; set; } = string.Empty;


        [Required]
        [StringLength(500)]
        public string CoreValues { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
