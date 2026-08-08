using System;
using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.Models
{
    public class AuditLog
    {
        [Key]
        public long AuditId { get; set; }

        public Guid? UserId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Action { get; set; } = string.Empty;

        [MaxLength(200)]        
        public string Entity { get; set; } = string.Empty;

        [MaxLength(200)]
        public string EntityId { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [MaxLength(2000)]
        public string Details { get; set; } = string.Empty;
    }
}

