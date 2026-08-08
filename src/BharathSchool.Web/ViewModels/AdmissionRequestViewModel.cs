using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.ViewModels
{
    public class AdmissionRequestViewModel
    {
        [Required]
        [MaxLength(300)]
        public string ApplicantName { get; set; } = string.Empty;

        public DateTime? DOB { get; set; }

        [Required]
        [MaxLength(300)]
        public string ParentName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ParentContact { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int StandardAppliedId { get; set; }

        public decimal? FeeIntentAmount { get; set; }

        public List<IFormFile> SupportingDocuments { get; set; } = new List<IFormFile>();
    }
}
