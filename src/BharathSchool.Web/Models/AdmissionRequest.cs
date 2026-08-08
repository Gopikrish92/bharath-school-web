using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.Models
{
    public class AdmissionRequest
    {
        public int AdmissionRequestId { get; set; }

        [Required]
        [MaxLength(300)]
        public string ApplicantName { get; set; } = string.Empty;

        public DateTime? DOB { get; set; }

        [MaxLength(300)]
        public string ParentName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ParentContact { get; set; } = string.Empty;

        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public int? StandardAppliedId { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(50)]
        public string Status { get; set; } = "Inactive"; // Inactive/Active/Rejected

        public decimal? FeeIntentAmount { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; } = string.Empty;

        public ICollection<AdmissionFile> Files { get; set; } = new List<AdmissionFile>();
    }
}

