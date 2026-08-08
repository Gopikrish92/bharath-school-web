using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ActivityType { get; set; } = string.Empty;

        public DateTime? ActivityDate { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        public Guid? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Media> MediaItems { get; set; } = new List<Media>();
    }
}
