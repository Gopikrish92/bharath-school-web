using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.ViewModels
{
    public class StudentEditViewModel
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(150)]
        public string LastName { get; set; } = string.Empty;

        public DateTime? DOB { get; set; }

        [MaxLength(20)]
        public string Gender { get; set; } = string.Empty;

        public IFormFile PhotoFile { get; set; }

        [Required]
        public int StandardId { get; set; }

        [Required]
        public int SectionId { get; set; }

        [MaxLength(50)]
        public string AdmissionStatus { get; set; } = "Inactive";

        [MaxLength(1000)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(300)]
        public string ParentName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ParentContact { get; set; } = string.Empty;

        public string CurrentPhotoPath { get; set; } = string.Empty;
    }
}
