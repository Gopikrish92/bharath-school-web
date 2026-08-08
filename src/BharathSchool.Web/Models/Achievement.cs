using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class Achievement
    {
        public int AchievementId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public int Year { get; set; }

        public int? Rank { get; set; }

        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(512)]
        public string PhotoPath { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Remarks { get; set; } = string.Empty;

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
