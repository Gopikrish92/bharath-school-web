using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class Media
    {
        public int MediaId { get; set; }

        public int? ActivityId { get; set; }

        [Required]
        [MaxLength(512)]
        public string FilePath { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string MediaType { get; set; } = string.Empty; // image/video

        [MaxLength(512)]
        public string ThumbnailPath { get; set; } = string.Empty;

        public Guid? UploadedBy { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }
    }
}
