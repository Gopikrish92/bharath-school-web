using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class Sport
    {
        public int SportId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(512)]
        public string PhotoPath { get; set; } = string.Empty;

        public bool IsCoached { get; set; }

        public int? CoachId { get; set; }

        [ForeignKey("CoachId")]
        public Coach Coach { get; set; }
    }
}
