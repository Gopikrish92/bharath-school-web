using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class AdmissionFile
    {
        public int AdmissionFileId { get; set; }

        [Required]
        public int AdmissionRequestId { get; set; }

        [Required]
        [MaxLength(512)]
        public string FilePath { get; set; } = string.Empty;

        [MaxLength(100)]
        public string FileType { get; set; } = string.Empty; // BirthCertificate, ParentID, etc.

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("AdmissionRequestId")]
        public AdmissionRequest AdmissionRequest { get; set; }
    }
}
